using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

    [Range (0f,500f)]
    public float health = 100;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void DealDamage(float damage)
    {
        health -= damage;

        //Debug.Log(name + " took " + damage + " damage");

        if (health <= 0)
        {
            //Die state
            //Debug.Log(name + " killed");
            KillObject();
        }
    }

    public void KillObject()
    {
        Destroy(gameObject);
    }
}
