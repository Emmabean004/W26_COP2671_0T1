using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using static UnityEngine.GraphicsBuffer;

public class GameManager : MonoBehaviour
{
public List<GameObject> targets;
private int score;
public bool isGameActive;
public GameObject titleScreen;
    public Button restartButton;
public TextMeshProUGUI scoreText;
public TextMeshProUGUI gameOverText;
private float spawnRate = 1.0f;
public int difficulty;
public void StartGame(int difficulty)
{
 StartCoroutine(SpawnTarget());
 score = 0;
 scoreText.gameObject.SetActive(true);
 isGameActive = true;
 UpdateScore(0);
 titleScreen.gameObject.SetActive(false);
 spawnRate /= difficulty;
}
public void RestartGame()
{
        Debug.Log("Restarting Game...");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
}
void Start()
{
    
}
public void GameOver()
{
    gameOverText.gameObject.SetActive(true);
    isGameActive = false;
    restartButton.gameObject.SetActive(true);

}
IEnumerator SpawnTarget()
{
    while (isGameActive)
    {
        yield return new WaitForSeconds(spawnRate);
        int index = Random.Range(0, targets.Count);
        Instantiate(targets[index]);
    }
}
public void UpdateScore(int scoreToAdd)
{
    score += scoreToAdd;
    scoreText.text = "Score: " + score;
}

}
