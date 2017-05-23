using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

	private GameObject player;

	private Vector3 offset;
	// Use this for initialization
	void Start () {
        GameManager manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        player = manager._player;
    }
	
	// Update is called once per frame
	void LateUpdate () {
        transform.position = player.transform.position + offset;
	}
}
