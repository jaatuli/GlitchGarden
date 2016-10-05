using UnityEngine;
using System.Collections;

public class Defender : MonoBehaviour {
    private StarDisplay starDisplay;
    public int starCost;

    private AudioSource starSound;

	// Use this for initialization
	void Start () {
        starDisplay = GameObject.FindObjectOfType<StarDisplay>();

        starSound = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        
    }

    public void AddStars (int amount) {

        starDisplay.AddStars(amount);
        starSound.Play();
    }


}
