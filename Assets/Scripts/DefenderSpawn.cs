using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DefenderSpawn : MonoBehaviour {

    public GameObject defenderPrefab;    
    public static GameObject selectedDefender;
    public bool defaultDefender = false;

    private DefenderSpawn[] buttonArray;
    private Text costText;
    

    // Use this for initialization
    void Start () {
        buttonArray = GameObject.FindObjectsOfType<DefenderSpawn>();
        
        if (defaultDefender) {
            selectedDefender = defenderPrefab;

            foreach (DefenderSpawn thisButton in buttonArray) {
                thisButton.GetComponent<SpriteRenderer>().color = Color.black;
            }

            GetComponent<SpriteRenderer>().color = Color.white;
        }

        costText = GetComponentInChildren<Text>();

        costText.text = defenderPrefab.GetComponent<Defender>().starCost.ToString();

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
