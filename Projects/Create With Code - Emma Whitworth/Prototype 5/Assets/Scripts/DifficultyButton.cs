using UnityEngine;
using UnityEngine.UI;
public class DifficultyButton : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private Button button;
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(SetDifficulty);
    }
    void SetDifficulty()
    {
        Debug.Log(gameObject.name + " was clicked");

    }
}
