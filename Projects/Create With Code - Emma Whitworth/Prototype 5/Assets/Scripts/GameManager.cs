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
public Button restartButton;
public TextMeshProUGUI scoreText;
public TextMeshProUGUI gameOverText;
private float spawnRate = 1.0f;
public void RestartGame()
{
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
}
void Start()
{
    StartCoroutine(SpawnTarget());
    score = 0;
    isGameActive = true;
    UpdateScore(0);
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
