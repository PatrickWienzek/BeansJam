using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Management : MonoBehaviour {
	private SceneManager scene;
	public GameObject beans;
	public GameObject logoText;
	private Animator animLogo;
	private bool done = false;

	private float timer;
	// Use this for initialization
	void Start () {
		animLogo = logoText.GetComponent<Animator> ();
		scene = new SceneManager ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space) && !done) {
			animLogo.SetBool ("leave", true);
			beans.SetActive (true);
			done = true;
		}

		if (Input.GetKeyDown (KeyCode.X) && done) {
            DontDestroyOnLoad(GameObject.Find("GameManager"));
            GameManager manager = GameObject.Find("GameManager").GetComponent<GameManager>();
            Characters character =  GameObject.Find("Bohnen").GetComponent<Characters>();
            manager.SetCharacter(character.GetChosenChar().name);
            SceneManager.LoadScene ("BeansJamScene");
		}
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.Quit();
		}
	}
}
