﻿using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

    [Range (0f, 5f)]
    public float speed = 1;
    [Range(0f, 50f)]
    public float damage = 10;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.right * speed * Time.deltaTime, Space.World);
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}