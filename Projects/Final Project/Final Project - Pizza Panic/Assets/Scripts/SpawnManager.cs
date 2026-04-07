using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager instance;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject[] objectPrefab;
    public GameObject customer;
    //list of X Positions to spawn objects at
    public List<float> spawnPosX;
    private float spawnRangeX = 3;
    private float spawnPosZ = -4.4f;
    private float customerSpawnPosZ = 2.5f; 
    private float startDelay = 2;
    private int bombChance = 8;
    private float spawnInterval = 1.0f;
    private float customerSpawnInterval = 2.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        InvokeRepeating("SpawnObjects", startDelay, spawnInterval);
        InvokeRepeating("SpawnCustomer", startDelay, customerSpawnInterval);
    }
    void SpawnObjects()
    {
        int objectIndex;
        if (Random.Range(0, 10) <  bombChance)
        {
            objectIndex = 0;
        }
        else
        {
            objectIndex = 1;
        }

       
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 8, spawnPosZ);

        Instantiate(objectPrefab[objectIndex], spawnPos, objectPrefab[objectIndex].transform.rotation);
    }

    void SpawnCustomer()
    {
        // Create a local copy of spawnPosX to avoid modifying the original list during iteration
        List<float> availableSpawnPosX = new List<float>(spawnPosX);

        int customerCount = Random.Range(1, 2);
        for (int i = 0; i < customerCount; i++)
        {
            if (availableSpawnPosX.Count == 0)
            {
                break;
            }

            int posIndex = Random.Range(0, availableSpawnPosX.Count);
            float customerpos = availableSpawnPosX[posIndex];
            Vector3 spawnPos = new Vector3(customerpos, 0.9f, customerSpawnPosZ);
            Instantiate(customer, spawnPos, customer.transform.rotation);

            // Remove the used position to prevent multiple customers at the same position
            availableSpawnPosX.RemoveAt(posIndex);
        }
    }
    void RestorePosition(float SpawnPos)
    {
         spawnPosX.Add(SpawnPos);
    }
    void Update()
    {
        
    }


}
