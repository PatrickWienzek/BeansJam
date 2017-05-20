using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationPlanet : MonoBehaviour {

    public bool jump = false;
    public float rotationSpeed = 0.5f;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (!jump)
        {
            transform.Rotate(new Vector3(0, 0, Input.GetAxis("Horizontal") * rotationSpeed));
        }
    }

    public void isJumping(bool jumped)
    {
        jump = jumped;
    }
}
