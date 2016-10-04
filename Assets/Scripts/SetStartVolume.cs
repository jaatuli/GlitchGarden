using UnityEngine;
using System.Collections;

public class SetStartVolume : MonoBehaviour {

    private MusicManager musicManager;


    // Use this for initialization
    void Start () {

        musicManager = GameObject.FindObjectOfType<MusicManager>();
        musicManager.SetVolume(PlayerPrefsManager.GetMasterVolume());

        // Set default settings if player has not played before
        if (PlayerPrefsManager.GetHasPlayed() == 0) {
            OptionsController.SetInitialDefaults();
        }
    }	

}
