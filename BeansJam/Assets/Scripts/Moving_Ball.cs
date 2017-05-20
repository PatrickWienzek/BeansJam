using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving_Ball : MonoBehaviour {

	//public ParticleSystem part;
	//private ParticleSystem.EmissionModule em;

	private Rigidbody2D rb;
	private float acc = 1.1f;
	private float rotOverTime = 0f;


	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		Physics2D.gravity = Vector2.zero;
		//part = GameObject.Find ("death_crush1").GetComponent<ParticleSystem>();
		//em = part.emission;
	}
	
	// Update is called once per frame
	void Update () {
		rotOverTime += Time.deltaTime;
		rb.AddForce(new Vector2(-3,0) * acc);
		rb.MoveRotation (50.0f * rotOverTime);
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		Debug.Log ("HI");
		if (other.tag == "Player") {
			//em.enabled = true;
			//other.GetComponent<SpriteRenderer> ().enabled = false;
			Destroy (other.gameObject, 0.2f);
		}
	}
}
