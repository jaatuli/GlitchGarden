using UnityEngine;
using System.Collections;

public class InfoPanel : MonoBehaviour {

    public float infoSpawnPanelDelay;

    private GameTimer gameTimer;
    private DefenderSpawner defenderSpawner;
    private GameObject[] actors;

    // Use this for initialization
    void Start() {
        gameTimer = GameObject.FindObjectOfType<GameTimer>();
        defenderSpawner = GameObject.FindObjectOfType<DefenderSpawner>();
        actors = GameObject.FindGameObjectsWithTag("gameActors");

        // Hide panel at start
        HideInfoPanel();

        // Disable game
        DisableGame();

        //Show info after while
        if (PlayerPrefsManager.GetHasPlayed() == 0) {
            Invoke("ShowInfoPanel", infoSpawnPanelDelay);
        } else {
            EnableGame();
        }

    }

    void EnableGame() {
        gameTimer.timerEnabled = true;
        defenderSpawner.spawningEnabled = true;
        

        foreach (GameObject thisActor in actors) {
            thisActor.SetActive(true);
        }
    }

    void DisableGame() {
        gameTimer.timerEnabled = false;
        defenderSpawner.spawningEnabled = false;
        actors = GameObject.FindGameObjectsWithTag("gameActors");

        foreach(GameObject thisActor in actors) {
            thisActor.SetActive(false);
        }

    }

    public void HideInfoPanel() {
        EnableGame();
        gameObject.SetActive(false);
    }

    public void ShowInfoPanel () {
        DisableGame();
        gameObject.SetActive(true);
    }

    void OnMouseDown() {
        HideInfoPanel();        
    }
}

