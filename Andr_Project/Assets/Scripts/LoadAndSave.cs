using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/** Klasse zum Speichern und Laden von Werten */
public class LoadAndSave : MonoBehaviour {

	/**Initialisierung */
	private void Awake () {
        Values.Volume = PlayerPrefs.GetFloat("volume");
        Values.selectionIndex = PlayerPrefs.GetInt("index");
	}
    
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
    /** Werte werden beim Pausieren gespeichert */
    private void OnApplicationPause(bool pause)
    {
        if(pause)
        {
            PlayerPrefs.SetFloat("volume", Values.Volume);
            PlayerPrefs.SetInt("index", Values.selectionIndex);
            PlayerPrefs.Save();
        }
    }
    /** Werte werden beim Verlassen der App gespeichert */
    private void OnApplicationQuit () {
        PlayerPrefs.SetFloat("volume", Values.Volume);
        PlayerPrefs.SetInt("index", Values.selectionIndex);
        PlayerPrefs.Save();
	}
}
