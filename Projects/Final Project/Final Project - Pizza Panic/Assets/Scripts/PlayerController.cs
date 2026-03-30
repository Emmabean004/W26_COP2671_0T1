using UnityEngine;
using TMPro;
using Unity.VisualScripting;
public class PlayerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float horizontalInput;
    public int misses = 0;
    public int score = 0;
    public float xRange = 10;
    public float speed = 10.0f;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timerText;
    public AudioClip collect;
    public AudioClip hit;
    public AudioSource musicSource;
    public AudioSource audioSource;
    float timeRemaining = 90;
    //public GameObject projectilePrefab;
    void Start()
    {
        
      
        
    }

    // Update is called once per frame
    void Update()
    {

        GameTimer();
        scoreText.text = "Score: " + score;
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
            //stop  the music
            musicSource.Stop();
            Debug.Log("Game Over!");
            Time.timeScale = 0;
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Hazard"))
        {
            misses++;
            // play hit sound
            audioSource.PlayOneShot(hit, 1.0f);
            Debug.Log("You Got Hit! " + (3 - misses) + "tries remaining");            
        }
        if (collision.gameObject.CompareTag("Collectible"))
        {
            //call the score function
            score++;
            Debug.Log("You Got A Collectible! Score:" + score);
            // play collect sound
            audioSource.PlayOneShot(collect, 1.0f);
        }
    }

    // create a game timer that counts down from 60 seconds and ends the game when it reaches 0\
    void GameTimer()
    {

        timeRemaining -= Time.deltaTime; // decrease the time remaining by the time that has passed since the last frame
        // flash the text between red and white when the time remaining is less than 10 seconds
        if (timeRemaining < 10)
            {
                timerText.color = Color.red;
            }
            else
            {
                timerText.color = Color.white;
        }
        if (timeRemaining <= 0)
        {
            Debug.Log("Time's Up! Final Score: " + score);
            Time.timeScale = 0; // stop the game
        }
        timerText.text = Mathf.Ceil(timeRemaining).ToString(); // display the time remaining as an integer
    }   
}