﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Analytics;
using System.Collections.Generic;

public class GameTimer : MonoBehaviour {

    public float levelSeconds = 120;

    private GameObject winLabel;
    private Slider slider;
    private AudioSource audioSource;
    private LevelManager levelManager;    
    private bool isEndOfLevel = false;
    private MusicManager musicManager;

    // Use this for initialization
    void Start() {
        slider = GetComponent<Slider>();
        audioSource = GetComponent<AudioSource>();
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        musicManager = GameObject.FindObjectOfType<MusicManager>();

        winLabel = GameObject.Find("WinCanvas");

        winLabel.SetActive(false);     
        
    }
	// Update is called once per frame
	void Update () {

        slider.value = GetLevelProgression();

        if (Time.timeSinceLevelLoad >= levelSeconds && !isEndOfLevel) {

            HandleWinCondition();
            Analytic.LevelEndAnalytics(true);

        }
        	
	}

    void HandleWinCondition() {
        isEndOfLevel = true;

        // Disable lose collider
        GameObject.FindObjectOfType<LoseCollider>().gameObject.SetActive(false);

        if (musicManager) {
            musicManager.StopPlaying();
        }
        audioSource.Play();
        winLabel.SetActive(true);
        PlayerPrefsManager.UnlockLevel(levelManager.GetCurrentLevel() - 2);
        Invoke("LoadNextLevel", audioSource.clip.length);
        DestroyAllGameObjects();

    }

    void DestroyAllGameObjects() {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("destroyOnWin");
        AttackerSpawner spawner = GameObject.FindObjectOfType<AttackerSpawner>();

        spawner.gameObject.SetActive(false);

        foreach (GameObject thisObject in objects) {
            Destroy(thisObject);
        }
    }

    public float GetLevelProgression() {
        return Time.timeSinceLevelLoad / levelSeconds;
    }

    void LoadNextLevel() {
        
        levelManager.LoadNextLevel();
    }
}
