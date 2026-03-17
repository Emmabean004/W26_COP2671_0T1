using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject[] objectPrefab;
    private float spawnRangeX = 3;
    private float spawnPosZ = -4.4f;
    private float startDelay = 2;
    private int bombChance = 8;
    private float spawnInterval = 1.5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("SpawnObjects", startDelay, spawnInterval);
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


    void Update()
    {

    }

}
