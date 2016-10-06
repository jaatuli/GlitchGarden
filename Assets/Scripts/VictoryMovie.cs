using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class VictoryMovie : MonoBehaviour {

    //public MovieTexture movie;    
    private AudioSource audioSource;    

    // Use this for initialization
    void Start() {
        
        if (PlayerPrefsManager.GetDifficulty() == 3) {

            if (Application.platform == RuntimePlatform.Android) {
                Handheld.PlayFullScreenMovie("Congratulations.mp4", Color.black, FullScreenMovieControlMode.CancelOnInput);
            }
            
            /* if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer) { 
            
                //Init
                audioSource = GetComponent<AudioSource>();
                image.GetComponent<RawImage>().texture = movie;

                audioSource.clip = movie.audioClip;

                movie.Play();
                audioSource.Play();                
                
            }*/
        }

    }

    /* void Update() {

        if (!movie.isPlaying) {
            image.SetActive(false);
        }
    }*/
}
