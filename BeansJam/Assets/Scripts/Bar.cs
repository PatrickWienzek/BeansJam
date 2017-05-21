using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bar : MonoBehaviour {
	

	public float health;

	[SerializeField]
	private Image content;

	public 	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		content.fillAmount = health;
    }
}
