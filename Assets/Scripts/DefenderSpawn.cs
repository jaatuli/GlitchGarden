using UnityEngine;
using System.Collections;

public class DefenderSpawn : MonoBehaviour {

    public GameObject defenderPrefab;

    private DefenderSpawn[] buttonArray;
    public static GameObject selectedDefender;

	// Use this for initialization
	void Start () {
        buttonArray = GameObject.FindObjectsOfType<DefenderSpawn>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDown() {
        foreach (DefenderSpawn thisButton in buttonArray) {
            thisButton.GetComponent<SpriteRenderer>().color = Color.black;
        }

        GetComponent<SpriteRenderer>().color = Color.white;

        if(defenderPrefab) {
            selectedDefender = defenderPrefab;
        }

    }
}
