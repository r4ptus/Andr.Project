using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    public AudioMixer audioMixer;
    public Slider Slider;

    public void Start()
    {
        audioMixer.SetFloat("volume", Values.Volume);
        Slider.value = Values.Volume;
    }

    /// <summary>
    /// Function to Start the Singleplayergame
    /// loads the next scene in the queue
    /// </summary>
	public void Play1PMode()
    {
        Values.is2PMode = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    /// <summary>
    /// Function to quit the app
    /// </summary>
    public void QuitGame()
    {
        Application.Quit();
    }

    /// <summary>
    /// Function for setting the volume of the game
    /// </summary>
    /// <param name="volume"></param>
    public void SetVolume(float volume)
    {
        Values.Volume = volume;
        audioMixer.SetFloat("volume", volume);
    }

    public void Play2PMode()
    {
        Values.is2PMode = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
