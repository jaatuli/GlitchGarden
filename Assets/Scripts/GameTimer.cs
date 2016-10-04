using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour {

    public float levelSeconds = 120;
    public GameObject winLabel;

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
        
        winLabel.SetActive(false);     
        
    }
	// Update is called once per frame
	void Update () {

        slider.value = Time.timeSinceLevelLoad / levelSeconds;

        if (Time.timeSinceLevelLoad >= levelSeconds && !isEndOfLevel) {
            isEndOfLevel = true;

            // Disable lose collider
            GameObject.FindObjectOfType<LoseCollider>().gameObject.SetActive(false);

            musicManager.StopPlaying();
            audioSource.Play();
            winLabel.SetActive(true);
            Invoke("LoadNextLevel", audioSource.clip.length);
        }
        	
	}

    void LoadNextLevel() {
        levelManager.LoadNextLevel();
    }
}
