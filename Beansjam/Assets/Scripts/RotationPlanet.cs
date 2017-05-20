using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationPlanet : MonoBehaviour {

    public bool jump = false;
    public float rotationSpeed = 2.0f;

    public bool IsCurrentPlanet = false;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (IsCurrentPlanet && !jump)
        {
            var rotateBy = Input.GetAxis("Horizontal") * rotationSpeed;
            transform.Rotate( new Vector3(0, 0, rotateBy));

            foreach(var planet in GameObject.FindGameObjectsWithTag("Planet")) {
                var diff = planet.transform.position - this.transform.position;
                var quat = Quaternion.Euler(0, 0, rotateBy);
                diff = quat * diff;
                planet.transform.position = this.transform.position + diff;
            }
        }
    }

    public void isJumping(bool jumped)
    {
        jump = jumped;
    }
}
