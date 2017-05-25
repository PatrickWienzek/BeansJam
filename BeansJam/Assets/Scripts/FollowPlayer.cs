using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {
    private Camera cam;
	private GameObject player;
    private GameManager manager;
	private Vector3 offset;
	// Use this for initialization
	void Start () {
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        player = manager.GetCharacter();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.position = player.transform.position;
	}
}
