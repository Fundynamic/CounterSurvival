using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

public class EnemySpawnScript : MonoBehaviour
{

	private float nextSpawnTime;
	public float SpawnRateInSeconds = 10;
	public GameObject EnemyToSpawn;
	public GameObject TargetForEnemies;
	
	// Use this for initialization
	void Start ()
	{
		nextSpawnTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {

		if (Time.time > nextSpawnTime)
		{
			var whereToSpawn = new Vector3(gameObject.transform.position.x + 0.2f, gameObject.transform.position.y + 0.2f,0f);		
			Debug.Log("Spawn at: "+whereToSpawn);
			var enemy = Instantiate(EnemyToSpawn, whereToSpawn, Quaternion.identity);
			var destinationSetter = enemy.GetComponent<AIDestinationSetter>();
			destinationSetter.target = TargetForEnemies.transform;
			
			nextSpawnTime = Time.time + SpawnRateInSeconds;
		}
	}
}
