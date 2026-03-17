using UnityEngine;
using TMPro; // Import the TextMeshPro library

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // Reference to the UI text element
    private int score; // The variable to store the score
    public GameObject player;
    void Start()
    {
        score = 0; // Initialize the score
        UpdateScoreText(); // Display the initial score
    }

    // Call this method whenever the score changes
    public void AddScore(int amount)
    {
        score += amount; // Increment the score
        UpdateScoreText(); // Update the UI text
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score.ToString(); // Set the text string
    }
}