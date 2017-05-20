using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Player : MonoBehaviour {

    public int live = 3;
    public float speed = 0.55f;
    public float jumpForce = 15.0f;
    private Rigidbody2D _rigidbody;
    private RotationPlanet _planet;
    private bool _jumpPossible = false;
    private Transform _jumpForcePosition;
    private Transform _planetCore;



	// Use this for initialization
	void Start () {
        _rigidbody = GetComponent<Rigidbody2D>();
        _planet = GameObject.FindGameObjectWithTag("Planet").GetComponent<RotationPlanet>();
        _planetCore = GameObject.FindGameObjectWithTag("Planet").transform.GetChild(0);
        _jumpForcePosition = transform.GetChild(1).transform;
    }
	
	// Update is called once per frame
	void Update () {

        Move();

        var nearestPlanet = (
            from planet in GameObject.FindGameObjectsWithTag("Planet")
            let distance = (planet.transform.position - this.transform.position)
            orderby distance.sqrMagnitude
            select planet
        ).FirstOrDefault();

        foreach(var planet in GameObject.FindGameObjectsWithTag("Planet")) {
            planet.GetComponent<RotationPlanet>().enabled = planet == nearestPlanet;
        }
        Gravity();
    }

    private void Move()
    {
        transform.Translate(Input.GetAxis("Horizontal") * speed, 0, 0);

        if (Input.GetKey(KeyCode.Space) && _jumpPossible)
        {
            _rigidbody.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
            _planet.isJumping(true);
        }
        else
        {
            _planet.isJumping(false);
        }
    }

    void Gravity()
    {
        if(!_jumpPossible)
        {
            //Gravity towards the Planetcore on the current planet
            transform.position = Vector3.MoveTowards(transform.position, _planetCore.position, 0.2f);
            transform.up = transform.position - _planetCore.position;
        }

    }


    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider)
        {
            _jumpPossible = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider)
        {
            _jumpPossible = false;
        }
    }
}
