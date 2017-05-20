using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Player : MonoBehaviour {

    public int live = 3;
    public float speed = 0.55f;
    public float jumpForce = 50.0f;
    private Rigidbody2D _rigidbody;
    private RotationPlanet _planet;
    public float rotationSpeed = 120.0f;
    private bool _jumpPossible = false;
    private GameObject[] enemies;


	// Use this for initialization
	void Start () {
        _rigidbody = GetComponent<Rigidbody2D>();
        //_planet = GameObject.FindGameObjectWithTag("Planet").GetComponent<RotationPlanet>();
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.Space) && _jumpPossible)
        {
            _rigidbody.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
            //_planet.isJumping(true);

            transform.Translate(Input.GetAxis("Horizontal") * speed,0,0);
        }
        else
        {
            //_planet.isJumping(false);
        }

        var nearestPlanet = (
            from planet in GameObject.FindGameObjectsWithTag("Planet")
            let distance = (planet.transform.position - this.transform.position)
            orderby distance.sqrMagnitude
            select planet
        ).FirstOrDefault();

        var rotateBy = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;
        this.RotateObjects(nearestPlanet, rotateBy);
    }

    private void RotateObjects(GameObject nearestPlanet, float rotateBy) {
        foreach(var planet in GameObject.FindGameObjectsWithTag("Planet")) {
            RotateGameObject(nearestPlanet, planet, rotateBy);

            if(planet == nearestPlanet) {
                planet.transform.Rotate(0, 0, rotateBy);
            }
        }

        foreach(var enemy in enemies) {
            RotateGameObject(nearestPlanet, enemy, rotateBy);
        }
    }

    private void RotateGameObject(GameObject rotateAround, GameObject planet, float rotateBy) {
        var diff = planet.transform.position - rotateAround.transform.position;
        var quat = Quaternion.Euler(0, 0, rotateBy);
        diff = quat * diff;
        planet.transform.position = rotateAround.transform.position + diff;
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
