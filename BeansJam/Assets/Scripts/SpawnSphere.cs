using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSphere : MonoBehaviour {
	private GameObject player;
	public GameObject pref;
	public float waitTime = 2f;
	private float timer = 0f;
	private Vector3 playpos;

	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        player = GameObject.FindGameObjectWithTag("Player");
        playpos = player.transform.position;
		timer += Time.deltaTime;
		if (timer >= waitTime) {
			Destroy (Instantiate (pref, new Vector2 (playpos.x + 15,playpos.y + Random.Range (-5, 5)), Quaternion.identity), 10f);
			timer = timer % waitTime;
		}
	}
}
