using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BulletBehaviour : MonoBehaviour
{

	public float Speed = 2f;
	
	public Vector3 Target;

	public float Damage = 1f;
	
	private Rigidbody2D rb;
	

	// Use this for initialization
	void Start ()
	{
		rb = GetComponent<Rigidbody2D>();
		Vector3 difference = Target - transform.position;
		difference.Normalize();

		// Rotate player sprite
		float rotation_z = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(0f, 0f, rotation_z + -90);
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{			
		rb.velocity = transform.up * Speed;
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		Debug.Log("Bullet collided and destroyed!!: "+other);
//		var health = other.gameObject.GetComponent<Health>();
//		health.takeDamage(Damage);
		Destroy(gameObject);
		if (other.gameObject.CompareTag("Destructible"))
		{
			Destroy(other.gameObject);
		}
	}
	
}
