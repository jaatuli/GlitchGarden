using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour {

    [Range (0f, 500f)]
    public float rotationSpeed = 60;
	
    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(Vector3.back, rotationSpeed * Time.deltaTime);
    }
}
