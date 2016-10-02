using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class Attacker : MonoBehaviour {

    private float currentSpeed;
    private GameObject currentTarget;

	// Use this for initialization
	void Start () {

  	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.left * currentSpeed * Time.deltaTime, Space.World);
	}

    void OnTriggerEnter2D()
    {
    }

    public void setSpeed (float speed)
    {
        currentSpeed = speed;
    }

    // Called from the animator
    public void StrikeCurrentTarget (float damage)
    {
    }

    // Set to attack mode
    public void Attack (GameObject objectToAttack)
    {
        currentTarget = objectToAttack;
    }
}
