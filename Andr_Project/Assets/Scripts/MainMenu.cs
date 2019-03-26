using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;
/** Steuert das Hauptmenue */
public class MainMenu : MonoBehaviour {

    public AudioMixer audioMixer;
    public Slider Slider;
    public Dropdown Dropdown;
    public Dropdown ColorDropdown;
     /** Initialisierung */
    public void Start()
    {
        audioMixer.SetFloat("volume", Values.Volume);
        Slider.value = Values.Volume;
        Dropdown.value = Values.selectionIndex;
        ColorDropdown.value = Values.selectionIndexColor;
       
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
     /** Startet 2 - Spieler Modus */
    public void Play2PMode()
    {
        Values.is2PMode = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    /** Setzt anhand der Schwierigkeit die Geschwindgkeit der KI */
    public void SetAiDifficulty(int i)
    {
        Values.selectionIndex = i;

        if(i == 0)
        {
            Values.AiSpeed = 7.5f;
        }
        else if(i == 1)
        {
            Values.AiSpeed = 10;
        }
        else if(i == 2)
        {
            Values.AiSpeed = 15;
        }
    }


    /** Setzt die Farbe des Schlaegers */
    public void SetColour(int i)
    {
        Values.selectionIndexColor = i;

        if(i == 0)
        {
            Values.playerColour = Colour.Tuerkis;
            Debug.Log("Türkies");
        }
        else if (i == 1)
        {
            Values.playerColour = Colour.Red;
            Debug.Log("rot");
        }
        else if (i == 2)
        {
            Values.playerColour = Colour.Violett;
            Debug.Log("violett");
        }
        else if (i == 3)
        {
            Values.playerColour = Colour.Green;
            Debug.Log("Green");
        }
    }
}
