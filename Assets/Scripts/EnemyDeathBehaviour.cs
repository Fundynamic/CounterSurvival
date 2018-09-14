using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeathBehaviour : MonoBehaviour
{


	public GameObject DieEffect;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnDestroy()
	{
		var effect = Instantiate(DieEffect, transform.position, transform.rotation);
		Destroy(effect, 2);
	}
}
