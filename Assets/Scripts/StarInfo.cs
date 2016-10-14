using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StarInfo : MonoBehaviour {

    private Text starText;
    private int starCount = 0;

	// Use this for initialization
	void Start () {
        starText = GetComponentInChildren<Text>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void AddStars(int stars) {

        starCount += stars;

        starText.text = starCount.ToString();
    }
}
