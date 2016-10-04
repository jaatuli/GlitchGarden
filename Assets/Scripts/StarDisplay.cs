using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StarDisplay : MonoBehaviour {

    public int starCount;
    private Text myText;

	// Use this for initialization
	void Start () {
        myText = GetComponent<Text>();
        myText.text = starCount.ToString();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void AddStars (int amount) {
        starCount += amount;
        myText.text = starCount.ToString();
    }

    /// <summary>
    /// Debits number of stars from player. 
    /// </summary>
    /// <param name="amount">Amount of start to deduct</param>
    /// <returns>If successful, returns true, else false</returns>
    public bool UseStars (int amount) {
        if (amount <= starCount) {
            starCount -= amount;
            myText.text = starCount.ToString();
            return true;
        } else {
            return false;
        }

    }

}
