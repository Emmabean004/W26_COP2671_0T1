using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using System.Collections;
public class PlayerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float horizontalInput;
    public float xRange = 10;
    public float speed = 10.0f;
    public float fireRate = 0.5f; // Time between shots
    private float nextFireTime = 0f; // Time when the player can fire again
    public GameObject projectilePrefab;
    public AudioClip collect;
    public AudioClip hit;
    public AudioSource audioSource;
    //public GameObject projectilePrefab;
    void Start()
    {
        
      
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        // Launch a projectile from the player
        //Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        //}
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
        //code to shoot projectiles that are collected by the player below
        // code here

        if (Input.GetKeyDown(KeyCode.Space) && GameManager.instance.projectiles > 0 && Time.time >= nextFireTime)
        {
            nextFireTime = Time.time + fireRate;
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
            GameManager.instance.AddProjectile(-1);
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Hazard"))
        {
            GameManager.instance.AddMiss();
            audioSource.PlayOneShot(hit, 1.0f);
        }

        if (collision.gameObject.CompareTag("Collectible"))
        {
            GameManager.instance.AddScore(1);
            audioSource.PlayOneShot(collect, 1.0f);
            GameManager.instance.AddProjectile(1);
        }
    }
    public IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(0.5f); // Adjust the cooldown duration as needed
    }


}