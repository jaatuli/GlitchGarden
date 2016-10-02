using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

    public GameObject projectile;
    public Vector3 gunPosition;
    public GameObject projectilesParent;

	// Use this for initialization
	void Start () {        
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void Fire()
    {
        GameObject newProjectile = Instantiate(projectile);        
        newProjectile.transform.parent = projectilesParent.transform;
        newProjectile.transform.position = gameObject.transform.position + gunPosition;
    }
}
