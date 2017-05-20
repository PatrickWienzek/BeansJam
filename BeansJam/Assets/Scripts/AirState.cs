using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirState : MonoBehaviour {



	private float movex;
	private float movey;
	public float moveSpeed;

	private Rigidbody2D rig;
	// Use this for initialization
	void Start () {
		Physics2D.gravity = Vector2.zero;
		rig = GetComponent<Rigidbody2D> ();

	}

	// Update is called once per frame
	void FixedUpdate () {
		movex = Input.GetAxis ("Horizontal");
		movey = Input.GetAxis ("Vertical");

		rig.velocity = new Vector2 (movex * moveSpeed, movey * moveSpeed);
	
	}

}
