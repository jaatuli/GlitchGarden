using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SetStartVolume : MonoBehaviour {

    private MusicManager musicManager;
    private Text startText;


    // Use this for initialization
    void Start () {

        // Set default settings if player has not played before
        if (PlayerPrefsManager.GetHasPlayed() == 0) {
            OptionsController.SetInitialDefaults();
            PlayerPrefsManager.SetHasPlayed();
        }

        musicManager = GameObject.FindObjectOfType<MusicManager>();
        musicManager.SetVolume(PlayerPrefsManager.GetMasterVolume());

        startText = GameObject.Find("Start Button").GetComponent<Text>();

        if (PlayerPrefsManager.GetHasPlayed() == 1) {
            if(PlayerPrefsManager.IsLevelUnlocked(3)) {
                startText.text = "Restart";
            } else {
                startText.text = "Resume";
            }
            
        } else {
            startText.text = "Start";
        }
    }	

}
