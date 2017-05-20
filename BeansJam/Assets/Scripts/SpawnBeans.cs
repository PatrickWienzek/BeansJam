using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBeans : MonoBehaviour {

	private float lerp = 0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (lerp < 1f) {
			lerp += Time.deltaTime;

			transform.localScale = Vector3.Lerp (new Vector3 (0, 0, 0), new Vector3 (1, 1, 1), lerp);
		}
	}
}
