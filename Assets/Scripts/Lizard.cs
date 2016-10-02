using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Attacker))]
[RequireComponent(typeof(Animator))]
public class Lizard : MonoBehaviour {

    private Animator anim;
    private Attacker attacker;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        attacker = GetComponent<Attacker>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collider)
    {

        GameObject collidedObject = collider.gameObject;

        if (!collidedObject.GetComponent<Defender>())
        {
            return;
        }
        
        anim.SetBool("isAttacking", true);
        attacker.Attack(collidedObject);
        Debug.Log(name + " is attacking " + collidedObject);

    }
}
