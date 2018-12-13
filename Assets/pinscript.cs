using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pinscript : MonoBehaviour {
	public bool ispinned=false;
	public float speed=10f;
	private gamemanager gamemanager;
	public Rigidbody2D rb;

	void Start()
	{
		gamemanager = FindObjectOfType<gamemanager> ();
	}
	void Update () {
		if(!ispinned)
		rb.MovePosition (rb.position + Vector2.up * speed * Time.deltaTime);

	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.tag == "rotator") {
			transform.SetParent (col.transform);
			gamemanager.scoreupdate();
			col.GetComponent<rotatorscript> ().speed += 10f;

			ispinned = true;
		} else if (col.tag == "pin") 
		{
			gamemanager.gameover ();
		}
	}
}
