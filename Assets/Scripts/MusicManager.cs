using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {

    public AudioClip[] levelMusic;

    private AudioSource audioSource;

	void Awake()
    {
        DontDestroyOnLoad(gameObject);
        Debug.Log("Dont destroy on Load:" + name);
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
	
	void OnLevelWasLoaded(int level)
    {
        AudioClip thisLevelMusic = levelMusic[level];
        Debug.Log("Playing clip: " + thisLevelMusic);

        if (thisLevelMusic) // If there is music attached
        {
            audioSource.clip = thisLevelMusic;
            audioSource.loop = true;
            audioSource.Play();
        }

    }

    public void SetVolume (float volume)
    {
        audioSource.volume = volume;
    }

    public void StopPlaying () {
        audioSource.Stop();
    }
}
