﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadAndSave : MonoBehaviour {

	// Use this for initialization
	private void Awake () {
        Values.Volume = PlayerPrefs.GetFloat("volume");
	}

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void OnApplicationPause(bool pause)
    {
        if(pause)
        {
            PlayerPrefs.SetFloat("volume", Values.Volume);
            PlayerPrefs.Save();
        }
    }

    private void OnApplicationQuit () {
        PlayerPrefs.SetFloat("volume", Values.Volume);
        PlayerPrefs.Save();
	}
}