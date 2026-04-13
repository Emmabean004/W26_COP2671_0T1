using UnityEngine;
using TMPro;
using System.Collections;
using System.IO;
using Unity.VectorGraphics;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public static bool isPaused = false;
    public int score = 0;
    public int misses = 0;
    public int projectiles = 0;
    public float timeRemaining = 90;


    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI pauseText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI gameOverScoreText;
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
        UiVisibility(true, true, true);
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


    public void UiVisibility(bool scoreVisibility, bool timerVisibility, bool missVisibility)
    {
        scoreText.gameObject.SetActive(scoreVisibility);
        timerText.gameObject.SetActive(timerVisibility);
        missText[0].gameObject.SetActive(missVisibility);
        missText[1].gameObject.SetActive(missVisibility);
        missText[2].gameObject.SetActive(missVisibility);
       
    }
    public void PauseGame()
    {
        Time.timeScale = 0;
        isPaused = true;
        musicSource.Pause();
        UiVisibility(false, false, false);
        pauseText.gameObject.SetActive(true);
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
        isPaused = false;
        musicSource.Play();
        pauseText.gameObject.SetActive(false);
        UiVisibility(true, true, true);
    }
    IEnumerator Wait(float seconds)
    {
        yield return new WaitForSecondsRealtime(seconds);
    }
    public void SaveScores()
    {
        // Save to playerprefs
        PlayerPrefs.SetInt("Score", score);
        if (PlayerPrefs.HasKey("HighScore"))
        {
            if (score > PlayerPrefs.GetInt("HighScore"))
            {
                PlayerPrefs.SetInt("HighScore", score);
            }
        }
        else
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
        PlayerPrefs.Save();

    }
    void EndGame()
    {
        musicSource.Stop();
        gameOverText.gameObject.SetActive(true);
        gameOverScoreText.gameObject.SetActive(true);
        gameOverScoreText.text = "Final Score: " + score;
        highScoreText.gameObject.SetActive(true);
        UiVisibility(false, false, false);
        highScoreText.text = "High Score: " + PlayerPrefs.GetInt("HighScore");
        SaveScores();
        Time.timeScale = 0;
    }
    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}