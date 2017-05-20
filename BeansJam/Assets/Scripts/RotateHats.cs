using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateHats : MonoBehaviour {

	public GameObject[] hats;
	private int chosenChar = 2;
	private Vector3[] oldPos;
	private Vector3[] oldScale;
	private bool startLerpLeft = false;
	private bool startLerpRight = false;
	private float lerp = 0f;

	// Use this for initialization
	void Start () {
		oldPos = new Vector3[hats.Length];
		oldScale = new Vector3[hats.Length];
		for(int i = 0; i < oldPos.Length; i++)
		{
			oldPos[i] = hats[i].transform.position;
		}
		for(int i = 0; i < oldPos.Length; i++)
		{
			oldScale[i] = hats[i].transform.localScale;
		}
	}

	// Update is called once per frame
	void Update () {
		if (!startLerpLeft ) {
			if (Input.GetKey (KeyCode.LeftArrow)) {
				startLerpLeft = true;
				chosenChar--;
			}
		}

		if (!startLerpRight) {
			if (Input.GetKey (KeyCode.RightArrow)) {
				startLerpRight = true;
				chosenChar++;
			}
		}

		if (startLerpLeft) {
			lerp += Time.deltaTime;
			for (int i = 0; i < hats.Length; i++) {
				if (lerp <= 1.0f) {
					if (i == hats.Length - 1) {
						hats [i].transform.position = Vector3.Lerp (oldPos[i], oldPos [0], lerp);
						hats [i].transform.localScale = Vector3.Lerp (oldScale[i], oldScale [0], lerp);

					} else {

						hats [i].transform.position = Vector3.Lerp (oldPos[i], oldPos [i + 1], lerp);
						hats [i].transform.localScale = Vector3.Lerp (oldScale[i], oldScale [i + 1], lerp);
					}
				} 
				if (lerp > 1.0f) {
					var pos = oldPos[0];
					var scal = oldScale [0];
					for (int j = 0; j < hats.Length; j++) {
						if (j == hats.Length - 1) {
							oldPos[j] = pos;
							oldScale[j] = scal;
						} else {
							oldPos [j] = oldPos [j + 1];
							oldScale[j] = oldScale [j + 1];
						}							
					}
					startLerpLeft = false;
					lerp = 0.0f;
				}
			}
		}

		if (startLerpRight) {
			lerp += Time.deltaTime;
			for (int i = hats.Length - 1; i >= 0; i--) {
				if (lerp <= 1.0f) {
					if (i == 0) {
						hats [i].transform.position = Vector3.Lerp (oldPos[i], oldPos [hats.Length - 1], lerp);
						hats [i].transform.localScale = Vector3.Lerp (oldScale[i], oldScale [hats.Length - 1], lerp);

					} else {
						hats [i].transform.position = Vector3.Lerp (oldPos[i], oldPos [i - 1], lerp);
						hats [i].transform.localScale = Vector3.Lerp (oldScale[i], oldScale [i - 1], lerp);
					}
				} 
				if (lerp > 1.0f) {
					var pos = oldPos[hats.Length - 1];
					var scal = oldScale [hats.Length - 1];
					for (int j = hats.Length - 1; j >= 0; j--) {
						if (j == 0) {
							oldPos[j] = pos;
							oldScale[j] = scal;
						} else {
							oldPos [j] = oldPos [j - 1];
							oldScale[j] = oldScale [j - 1];
						}							
					}
					startLerpRight = false;
					lerp = 0.0f;
				}
			}

		}
	}
	public GameObject GetChosenChar()
	{
		return hats [chosenChar];
	}
}
