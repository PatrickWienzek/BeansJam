using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public int live = 3;
    public float speed = 0.55f;
    public float jumpForce = 5.0f;
    private Rigidbody2D _rigidbody;
    private RotationPlanet _planet;


	// Use this for initialization
	void Start () {
        _rigidbody = GetComponent<Rigidbody2D>();
        _planet = GameObject.FindGameObjectWithTag("Planet").GetComponent<RotationPlanet>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Space))
        {
            _rigidbody.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
            _planet.isJumping(true);

            transform.Translate(Input.GetAxis("Horizontal") * speed,0,0);
        }
        else
        {
            _planet.isJumping(false);
        }
           
        
    }
}
