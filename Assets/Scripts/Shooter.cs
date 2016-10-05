using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

    public GameObject projectile;
    public Vector3 gunPosition;
    private GameObject projectilesParent;
    private Animator anim;
    private AttackerSpawner[] mySpawners;

	// Use this for initialization
	void Start () {
        projectilesParent = GameObject.Find("Projectiles");
        anim = GetComponent<Animator>();
        mySpawners = GameObject.FindObjectsOfType<AttackerSpawner>();

        if (!projectilesParent) {
            projectilesParent = new GameObject("Projectiles");
        }
	}
	
	// Update is called once per frame
	void Update () {
	    if (IsAttackerInLane()) {
            anim.SetBool("isAttacking", true);
        } else {
            anim.SetBool("isAttacking", false);
        }
	}

    bool IsAttackerInLane () {

        foreach (AttackerSpawner thisSpawner in mySpawners) {

            foreach (Transform attacker in thisSpawner.transform) {
                if (attacker.transform.position.x > transform.position.x && attacker.transform.position.y == transform.position.y) {
                    return true;
                }
            }
        }

        return false;
    }

    private void Fire()
    {
        GameObject newProjectile = Instantiate(projectile);        
        newProjectile.transform.parent = projectilesParent.transform;
        newProjectile.transform.position = gameObject.transform.position + gunPosition;
    }
}
