﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class LevelManager : MonoBehaviour {

    public float autoLoadNextLevelAfter;

    void Start() {
        if (autoLoadNextLevelAfter <= 0) {
            //Debug.Log("Auto level load disabled, use positive value");
        }
        else {
            Invoke("LoadMenu", autoLoadNextLevelAfter);
        }
    }

    public void LoadLevel(string name) {
        Debug.Log("New Level load: " + name);
        SceneManager.LoadScene(name);
    }

    public void LoadMenu() {
        SceneManager.LoadScene("01a_Start");
    }

    public void QuitRequest() {
        Debug.Log("Quit requested");
        Application.Quit();
    }

    public void LoadNextLevel() {
        PlayerPrefsManager.SetHasPlayed();

        if (Advertisement.IsReady()) {
            Advertisement.Show();
            StartCoroutine(ShowAd());
        } else {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    IEnumerator ShowAd() {
        yield return new WaitWhile(() => Advertisement.isShowing);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public int GetCurrentLevel() {
        return SceneManager.GetActiveScene().buildIndex;
    }

    public void StartTheGame() {

        if (PlayerPrefsManager.IsLevelUnlocked(3)) {
            Debug.Log("Level 3 unlocked, restarting from begining");
            LoadLevel("02_Level_01");
        } else if (PlayerPrefsManager.IsLevelUnlocked(2)) {
            Debug.Log("Level 2 unlocked, starting from level 3");
            LoadLevel("02_Level_03");
        } else if (PlayerPrefsManager.IsLevelUnlocked(1)) {
            Debug.Log("Level 1 unlocked, starting from level 2");
            LoadLevel("02_Level_02");
        } else {
            Debug.Log("No levels unlocked, starting from begining");            
            LoadLevel("02_Level_01");
        }

    }
}