using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooooooting : MonoBehaviour {
	private GameObject player;
	private Rigidbody2D rb;
	private float speed = 1000f;
	private Vector3 shootpos;

	// Use this for initialization
	void Start () {
		shootpos = transform.position;
		rb = GetComponent<Rigidbody2D>();
		Physics2D.gravity = Vector2.zero;
		player = GameObject.FindGameObjectWithTag ("Player");
		Vector3 direction = player.transform.position - shootpos;
		rb.AddForce(direction.normalized * speed);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
