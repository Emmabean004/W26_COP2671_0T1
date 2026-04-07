using System.Collections;
using UnityEngine;

public class CustomerScript : MonoBehaviour
{
    // Variable for the player's projectile, to detect collision.


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        StartCoroutine(DestroyAfterTime(5.0f));
    }
    IEnumerator DestroyAfterTime(float delay)
    {
        yield return new WaitForSeconds(delay);
        // Perform any extra logic here (e.g., play effect, decrease count)
        if (!SpawnManager.instance.spawnPosX.Contains(transform.position.x))
        {
            SpawnManager.instance.spawnPosX.Add(transform.position.x);
        }
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            StopCoroutine(DestroyAfterTime(5.0f));

            // Add score to the player
            GameManager.instance.AddScore(5);
            // Destroy the projectile
            Destroy(collision.gameObject);
            // Destroy the customer
            Destroy(gameObject);
            if (!SpawnManager.instance.spawnPosX.Contains(transform.position.x))
            {
                SpawnManager.instance.spawnPosX.Add(transform.position.x);
            }
        }
    }
}
