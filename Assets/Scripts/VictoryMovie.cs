using UnityEngine;
using System.Collections;

public class VictoryMovie : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Handheld.PlayFullScreenMovie("Congratulations.mp4", Color.black, FullScreenMovieControlMode.CancelOnInput);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
