using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

    public GameObject projectile;
    public Vector3 gunPosition;
    private GameObject projectilesParent;
    private Animator anim;
    private AttackerSpawner myLaneSpawner;

	// Use this for initialization
	void Start () {
        projectilesParent = GameObject.Find("Projectiles");
        anim = GetComponent<Animator>();
        SetMyLaneSpawner();

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
        if (myLaneSpawner.transform.childCount <= 0) {
            return false;
        }

        foreach (Transform attacker in myLaneSpawner.transform) {
            if (attacker.transform.position.x > transform.position.x) {
                return true;
            }
        }

        return false;
    }

    void SetMyLaneSpawner () {
        AttackerSpawner[] spawners = GameObject.FindObjectsOfType<AttackerSpawner>();

        foreach (AttackerSpawner thisSpawner in spawners) {
            if (thisSpawner.transform.position.y == transform.position.y) {
                myLaneSpawner = thisSpawner;
                return;
            }
        }

        Debug.LogError(name + " can't find spawner in lane");
    }

    private void Fire()
    {
        GameObject newProjectile = Instantiate(projectile);        
        newProjectile.transform.parent = projectilesParent.transform;
        newProjectile.transform.position = gameObject.transform.position + gunPosition;
    }
}
