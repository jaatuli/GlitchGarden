using UnityEngine;
using System.Collections;

public class Defender : MonoBehaviour {
    private StarDisplay starDisplay;
    public int starCost;

	// Use this for initialization
	void Start () {
        starDisplay = GameObject.FindObjectOfType<StarDisplay>();
	}
	
	// Update is called once per frame
	void Update () {
        
    }

    public void AddStars (int amount) {

        starDisplay.AddStars(amount);
    }


}
