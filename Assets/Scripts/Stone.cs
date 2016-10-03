using UnityEngine;
using System.Collections;

public class Stone : MonoBehaviour {

    private Animator anim;
    private GameObject attacker;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
    
	    if (!attacker)
        {
            anim.SetBool("isAttacked", false);
        }
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        // Check if not attacker
        if (!collider.gameObject.GetComponent<Attacker>())
        {
            return;
        }

        // Assign current attacker
        attacker = collider.gameObject;

        // Set attacked animation
        anim.SetBool("isAttacked", true);        
        Debug.Log(name + " is attacked by " + attacker);
    }
}
