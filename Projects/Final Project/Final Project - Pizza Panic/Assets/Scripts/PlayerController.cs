using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float horizontalInput;
    public int misses = 0;
    public int score = 0;
    public float xRange = 10;
    public float speed = 10.0f;
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
        if (misses >= 3)
        {
            Debug.Log("Game Over!");
            Time.timeScale = 0;
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Hazard"))
        {
            misses++;
            Debug.Log("You Got Hit! " + (3 - misses) + "tries remaining");
            
        }
        if (collision.gameObject.CompareTag("Collectible"))
        {
            score++;
            Debug.Log("You Got A Collectible! Score:" + score);
            
        }
    }
}