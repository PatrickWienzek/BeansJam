using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationPlanet : MonoBehaviour {

    public bool jump = false;

    public bool IsCurrentPlanet = false;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (IsCurrentPlanet && !jump)
        {
           
            //transform.Rotate( new Vector3(0, 0, rotateBy));

            //foreach(var planet in GameObject.FindGameObjectsWithTag("Planet")) {
            //    RotateGameObject(planet, rotateBy);
            //}


        }
    }

    

    public void isJumping(bool jumped)
    {
        jump = jumped;
    }
}
