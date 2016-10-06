using UnityEngine;
using System.Collections;

public class DefenderSpawner : MonoBehaviour {

    public Camera myCamera;

    private GameObject defenderParent;
    private StarDisplay starDisplay;
    private AudioSource spawnSound;

    // Use this for initialization
    void Start () {

        // Never sleep screen during play
        Screen.sleepTimeout = 0;        

        starDisplay = GameObject.FindObjectOfType<StarDisplay>();
        defenderParent = GameObject.Find("Defenders");
        spawnSound = GetComponent<AudioSource>();

        if (!defenderParent) {
            defenderParent = new GameObject("Defenders");
        }
    }
	
    void OnMouseDown()
    {
        Vector2 rawPos = CalculateWorldPointOfClick();
        Vector2 gridPos = SnapToGrid(rawPos);

        Debug.Log("Click position: " + rawPos);
        
        if (DefenderSpawn.selectedDefender) {

            int currentDefenderCost = DefenderSpawn.selectedDefender.GetComponent<Defender>().starCost;

            if (starDisplay.UseStars(currentDefenderCost)) {
                Instantiate(DefenderSpawn.selectedDefender, gridPos, Quaternion.identity, defenderParent.transform);
                spawnSound.Play();
            } else {
                Debug.Log("Not enough stars!");
            }
        } else {
            Debug.Log("Select defender to spawn");
        }

    }

    Vector2 SnapToGrid (Vector2 rawWorldPos) {

        float gridX = Mathf.Clamp(Mathf.RoundToInt(rawWorldPos.x),1f,9f);
        float gridY = Mathf.Clamp(Mathf.RoundToInt(rawWorldPos.y),1f,5f);        

        Vector2 gridPosition = new Vector2(gridX, gridY);

        return gridPosition;
          
    }

    Vector2 CalculateWorldPointOfClick () {
        float mouseX = Input.mousePosition.x;
        float mouseY = Input.mousePosition.y;
        float distanceFromCamera = 10f;

        Vector3 weirdTriplet = new Vector3(mouseX, mouseY, distanceFromCamera);
               
        Vector2 worldPosition = myCamera.ScreenToWorldPoint(weirdTriplet);

        return worldPosition;
        
    }


}
