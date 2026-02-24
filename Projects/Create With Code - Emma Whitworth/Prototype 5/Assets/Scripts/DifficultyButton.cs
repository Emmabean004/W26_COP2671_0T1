using UnityEngine;
using UnityEngine.UI;
public class DifficultyButton : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private Button button;
    private GameManager gameManager;
    public int difficulty;
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(SetDifficulty);
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    void SetDifficulty()
    {
        Debug.Log(gameObject.name + " was clicked");
        gameManager.StartGame(difficulty);
    }
}
