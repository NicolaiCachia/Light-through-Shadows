using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        
        if (AudioManager.Instance == null)
        {
            GameObject audioManager = new GameObject("AudioManager");
            audioManager.AddComponent<AudioSource>();
            audioManager.AddComponent<AudioManager>();
            AudioSource audioSource = audioManager.GetComponent<AudioSource>();
            audioSource.clip = Resources.Load<AudioClip>("rain-and-tears-sad-piano-music-with-rain-and-thunderstorm-7804"); 
            audioSource.playOnAwake = true;
            audioSource.loop = true;
            audioSource.Play();
        }

        SceneManager.LoadScene("SampleScene"); // Replace "MainGame" with the name of your main game scene
    }
}