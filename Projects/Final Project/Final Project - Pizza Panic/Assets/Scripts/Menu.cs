using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Menu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public Slider sfxSlider;

    void Start()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene("pp_main");
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("pp_menu");
        // make sure to reset the time scale in case the player is returning to the main menu from a paused state
        Time.timeScale = 1;
    }

    public void ChangeVolume(float volume)
    {
        AudioListener.volume = volume;
        PlayerPrefs.SetFloat("MusicVolume", volume);
    }
    public void ChangeSoundEffectsVolume(float sfxvolume)
    {
        sfxSlider.value = sfxvolume;
        PlayerPrefs.SetFloat("SFXVolume", sfxvolume);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
