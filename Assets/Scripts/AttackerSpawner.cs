using UnityEngine;
using System.Collections;

public class AttackerSpawner : MonoBehaviour {

    public GameObject[] attackerPrefabArray;
    [Range(0f,5f)]
    public int lanesToUse;
    public Vector2 firstLanePosition = new Vector2(12f, 5f);
    [Range(0f,1f)]
    public float startSpawnModifier = 0.2f;
    public float levelSpawnDelay = 5f;
    public float levelProgression;
    public float timeToSpawn;
    private GameTimer gameTimer;

	// Use this for initialization
	void Start () {

        gameTimer = GameObject.FindObjectOfType<GameTimer>();

        timeToSpawn = levelSpawnDelay;
	
	}
	
	// Update is called once per frame
	void Update () {


        int attackerIndex = Random.Range(0, attackerPrefabArray.Length);

        if (isTimeToSpawn()) {
            Spawn(attackerPrefabArray[attackerIndex]);
        }
        
	}

    bool isTimeToSpawn() {

        levelProgression = startSpawnModifier + (gameTimer.GetLevelProgression() * (1 - startSpawnModifier));

        timeToSpawn -= Time.deltaTime * PlayerPrefsManager.GetDifficulty() * levelProgression;

        if (timeToSpawn < 0) {
            timeToSpawn = levelSpawnDelay;
            return true;
        } else {
            return false;
        }

    }

    void Spawn(GameObject myGameObject) {
        GameObject myAttacker = Instantiate(myGameObject) as GameObject;
        myAttacker.transform.parent = transform;

        // Make random lane position starting from top
        float randomLane = Random.Range(0, lanesToUse);
        Vector2 randomPosition = new Vector2(firstLanePosition.x, firstLanePosition.y - randomLane);

        myAttacker.transform.position = randomPosition;
    }
}
