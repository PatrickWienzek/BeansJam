using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSphere : MonoBehaviour {
	
	public GameObject pref;
	public float waitTime = 2f;
	private float timer = 0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer >= waitTime) {
			Destroy (Instantiate (pref, new Vector2 (10, Random.Range (-5, 5)), Quaternion.identity), 10f);
			timer = timer % waitTime;
		}
	}
}
