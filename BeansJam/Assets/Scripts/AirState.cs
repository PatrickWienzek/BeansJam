using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirState : MonoBehaviour {

	private float maxSpeed = 10f;
	private float acc = 1.2f;
	private float speed = 1f;
	private Rigidbody2D rig;
	// Use this for initialization
	void Start () {
		Physics2D.gravity = Vector2.zero;
		rig = GetComponent<Rigidbody2D> ();
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.D)) {
			
			if (speed <= maxSpeed) {
				speed *= acc;
				rig.AddForce (new Vector2(speed,0));
			}
		}
		if (Input.GetKeyUp (KeyCode.D)) {
			rig.AddForce (Vector2.left * acc);
		}
		if (Input.GetKey(KeyCode.A)) {
			rig.AddForce (Vector2.left * acc);
		}

		if (Input.GetKeyUp (KeyCode.A)) {
			rig.AddForce (Vector2.right *acc);
		}
	}
}
