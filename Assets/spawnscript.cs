using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnscript : MonoBehaviour {

	public GameObject pinprefab;
	void Update () {

		if (Input.GetMouseButtonDown (0)) 
		{
			spawnpin ();
		}
		
	}

	void spawnpin()
	{
		Instantiate (pinprefab, transform.position, transform.rotation);
	}
}
