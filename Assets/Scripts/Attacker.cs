using UnityEngine;
using System.Collections;

public class Attacker : MonoBehaviour {

    private float currentSpeed;

	// Use this for initialization
	void Start () {
        Rigidbody2D myRigidbody = gameObject.AddComponent<Rigidbody2D>();
        myRigidbody.isKinematic = true;
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.left * currentSpeed * Time.deltaTime, Space.World);
	}

    void OnTriggerEnter2D()
    {
        Debug.Log(name + " trigger enter");
    }

    public void setSpeed (float speed)
    {
        currentSpeed = speed;
    }

    public void StrikeCurrentTarget (float damage)
    {
        Debug.Log(name + " caused damage " + damage);
    }
}
