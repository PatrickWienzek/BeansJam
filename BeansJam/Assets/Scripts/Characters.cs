using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Characters : MonoBehaviour {
	public GameObject[] chars;
	private int chosenChar = 2;
	private Vector3[] oldPos;
	private Vector3[] oldScale;
	private bool startLerpLeft = false;
	private bool startLerpRight = false;
	private float lerp = 0f;

	// Use this for initialization
	void Start () {
		oldPos = new Vector3[chars.Length];
		oldScale = new Vector3[chars.Length];
		for(int i = 0; i < oldPos.Length; i++)
		{
			oldPos[i] = chars[i].transform.position;
		}
		for(int i = 0; i < oldPos.Length; i++)
		{
			oldScale[i] = chars[i].transform.localScale;
		}
	}

	// Update is called once per frame
	void Update () {
		if (!startLerpLeft ) {
			if (Input.GetKey (KeyCode.LeftArrow)) {
				startLerpLeft = true;
				chosenChar--;
                if (chosenChar < 0)
                    chosenChar = chars.Length - 1;

			}
		}

		if (!startLerpRight) {
			if (Input.GetKey (KeyCode.RightArrow)) {
				startLerpRight = true;
				chosenChar++;
                if (chosenChar > chars.Length -1)
                    chosenChar = 0;
            }
		}

		if (startLerpLeft) {
			lerp += Time.deltaTime;
			for (int i = 0; i < chars.Length; i++) {
				if (lerp <= 1.0f) {
					if (i == chars.Length - 1) {
						chars [i].transform.position = Vector3.Lerp (oldPos[i], oldPos [0], lerp);
						chars [i].transform.localScale = Vector3.Lerp (oldScale[i], oldScale [0], lerp);

					} else {

						chars [i].transform.position = Vector3.Lerp (oldPos[i], oldPos [i + 1], lerp);
						chars [i].transform.localScale = Vector3.Lerp (oldScale[i], oldScale [i + 1], lerp);
					}
				} 
				if (lerp > 1.0f) {
					var pos = oldPos[0];
					var scal = oldScale [0];
					for (int j = 0; j < chars.Length; j++) {
						if (j == chars.Length - 1) {
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
			for (int i = chars.Length - 1; i >= 0; i--) {
				if (lerp <= 1.0f) {
					if (i == 0) {
						chars [i].transform.position = Vector3.Lerp (oldPos[i], oldPos [chars.Length - 1], lerp);
						chars [i].transform.localScale = Vector3.Lerp (oldScale[i], oldScale [chars.Length - 1], lerp);

					} else {
						chars [i].transform.position = Vector3.Lerp (oldPos[i], oldPos [i - 1], lerp);
						chars [i].transform.localScale = Vector3.Lerp (oldScale[i], oldScale [i - 1], lerp);
					}
				} 
				if (lerp > 1.0f) {
					var pos = oldPos[chars.Length - 1];
					var scal = oldScale [chars.Length - 1];
					for (int j = chars.Length - 1; j >= 0; j--) {
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

        return chars [chosenChar];
	}
}
