using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int score = 0;
    public int misses = 0;
    public int projectiles = 0;
    public float timeRemaining = 90;
    
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timerText;
    // limit 3 misses, so we can use an array to store the miss text objects
    public TextMeshProUGUI[] missText;
    public AudioSource musicSource;

    void Awake() // 
    {
        //assign color to all miss text to white at the start of the game
        missText[0].color = Color.white;
        missText[1].color = Color.white;
        missText[2].color = Color.white;
        instance = this;
    }

    void Update()
    {
        GameTimer();
        UpdateUI();
    }

    void GameTimer()
    {
        timeRemaining -= Time.deltaTime;

        if (timeRemaining < 10)
            timerText.color = Color.red;
        else
            timerText.color = Color.white;

        if (timeRemaining <= 0)
        {
            Debug.Log("Time's Up! Final Score: " + score);
            EndGame();
        }

        timerText.text = Mathf.Ceil(timeRemaining).ToString();
    }

    void UpdateUI()
    {
        scoreText.text = "Score: " + score;
    }

    public void AddScore(int amount)
    {
        score += amount;
    }
    public void AddProjectile(int amount)
    {
        projectiles += amount;
    }

    public void AddMiss()
    {
        misses++;

        if (misses >= 3)
        {
            Debug.Log("Game Over!");
            EndGame();
        }
        if (misses == 1)
        {
            missText[0].color = Color.red;
        }
        else if (misses == 2)
        {
            missText[1].color = Color.red;
        }
         else if (misses == 3)
        {
            missText[2].color = Color.red;
        }
    }

    void EndGame()
    {
        musicSource.Stop();
        Time.timeScale = 0;
    }
}