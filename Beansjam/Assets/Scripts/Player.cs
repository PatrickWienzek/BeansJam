﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Player : MonoBehaviour {

    public int live = 3;
    public float speed = 0.55f;
    public float jumpForce = 50.0f;
    private Rigidbody2D _rigidbody;
    private RotationPlanet _planet;
    private bool _jumpPossible = false;


	// Use this for initialization
	void Start () {
        _rigidbody = GetComponent<Rigidbody2D>();
        _planet = GameObject.FindGameObjectWithTag("Planet").GetComponent<RotationPlanet>();
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.Space) && _jumpPossible)
        {
            _rigidbody.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
            _planet.isJumping(true);

            transform.Translate(Input.GetAxis("Horizontal") * speed,0,0);
        }
        else
        {
            _planet.isJumping(false);
        }

        var nearestPlanet = (
            from planet in GameObject.FindGameObjectsWithTag("Planet")
            let distance = (planet.transform.position - this.transform.position)
            orderby distance.sqrMagnitude
            select planet
        ).FirstOrDefault();

        foreach(var planet in GameObject.FindGameObjectsWithTag("Planet")) {
            planet.GetComponent<RotationPlanet>().enabled = planet == nearestPlanet;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider)
        {
            _jumpPossible = true;
            Debug.Log("TEST JUMP TRUE");
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider)
        {
            _jumpPossible = false;
            Debug.Log("TEST JUMP FALSE");
        }
    }
}
