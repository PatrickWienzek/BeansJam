using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserPickUp : MonoBehaviour {

    public GameObject eduardLaser;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision) {
        var player = collision.gameObject;

        var position = player.transform.position;
        var rotation = player.transform.rotation;

        player.tag = "Default";
        player.GetComponentInChildren<SpriteRenderer>().enabled = false;
        player.SetActive(false);
        Destroy(player);

        Instantiate(eduardLaser, position, rotation);

        gameObject.SetActive(false);
    }
}
