using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class Projectile : MonoBehaviour {

    [Range (0f, 5f)]
    public float speed = 1;
    [Range(0f, 100f)]
    public float damage = 10;

    private AudioSource hitSound;

	// Use this for initialization
	void Start () {
        hitSound = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.right * speed * Time.deltaTime, Space.World);
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D (Collider2D collider)
    {
        Attacker attacker = collider.gameObject.GetComponent<Attacker>();
        Health health = collider.gameObject.GetComponent<Health>();

        if (attacker && health)
        {
            health.DealDamage(damage);
            hitSound.Play();
            Destroy(gameObject,0.1f);
        }
    }
}
