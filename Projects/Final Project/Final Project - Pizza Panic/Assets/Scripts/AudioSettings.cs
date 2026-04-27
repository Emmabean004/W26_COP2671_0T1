using UnityEngine;

public class AudioSettings : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    // Change the volume of the audio source attached to the same GameObject as this script
    //PlayerPrefs is used to save the volume setting between game sessions
    void Update()
    {

        // Load the saved volume setting, default to 1 (full volume) if not set
        float MusicVolume = PlayerPrefs.GetFloat("MusicVolume", 1f);
        float SFXVolume = PlayerPrefs.GetFloat("SFXVolume", 1f);
        AudioSource audioSource = GetComponent<AudioSource>();
        if (audioSource != null && gameObject.CompareTag("Music"))
        {
            audioSource.volume = MusicVolume;
        }
        if (audioSource != null && gameObject.CompareTag("SFX"))
        {
            audioSource.volume = SFXVolume;
        }
    }
}
