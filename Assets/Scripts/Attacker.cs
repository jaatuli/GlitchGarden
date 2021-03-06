﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class Attacker : MonoBehaviour {

    [Tooltip("Average number of seconds between appearences")]
    public float baseSpawnRate;
    private float currentSpeed;
    private GameObject currentTarget;
    private Animator anim;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.left * currentSpeed * Time.deltaTime, Space.World);
        if (!currentTarget)
        {
            anim.SetBool("isAttacking", false);
        }
	}    

    public void setSpeed (float speed)
    {
        currentSpeed = speed;
    }

    // Called from the animator
    public void StrikeCurrentTarget (float damage)
    {
        if (currentTarget)
        {
            Health health = currentTarget.GetComponent<Health>();

            if (health)
            {
                health.DealDamage(damage);
            }

        }
    }

    // Set to attack mode
    public void Attack (GameObject objectToAttack)
    {
        currentTarget = objectToAttack;
    }
}
