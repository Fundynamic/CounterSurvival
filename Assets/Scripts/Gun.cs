using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

	public float BulletSpeed = 2;

	public float FireRatePerSecond = 4;

	public float DamagePerBullet = 2;

	public GameObject BulletToFire;

	public GameObject Owner;

	private float lastTimeBulletFired;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetButton("Fire1"))
		{
			var currentTime = Time.time;

			if (ShouldFireBullet(currentTime))
			{
				FireGun(Camera.main.ScreenToWorldPoint(Input.mousePosition));
				lastTimeBulletFired = Time.time;
			}
		}
		
	}

	private void FireGun(Vector3 aimedAt)
	{
		Vector3 ownerPos = Owner.transform.position;
		Vector3 playerDirection = Owner.transform.up;
		Quaternion playerRotation = Owner.transform.rotation;
		float spawnDistance = 1;
 
		Vector3 spawnPos = ownerPos + playerDirection * spawnDistance;

		Debug.Log("Creating bullet at " + spawnPos + " , player at " + ownerPos + " forward " + playerDirection);
		//Spawn bullet
		var bulletObject = Instantiate(BulletToFire, spawnPos, playerRotation);
//		var bulletObject = Instantiate(BulletToFire, transform.position, Quaternion.identity);
		
		
		
		var bulletBehaviour = bulletObject.GetComponent<BulletBehaviour>();
		bulletBehaviour.Target = aimedAt;
		bulletBehaviour.Speed = BulletSpeed;
		bulletBehaviour.Damage = DamagePerBullet;
		
		
		//Set from, to
		//Set velocity, 
		//Set damage
	}

	private bool ShouldFireBullet(float currentTime)
	{
		return (currentTime - lastTimeBulletFired) >= 1f/FireRatePerSecond;
	}

	void FixedUpdate()
	{
		
	}
}
