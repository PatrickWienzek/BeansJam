using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class Moving_Ball : MonoBehaviour {

    //public ParticleSystem part;
    //private ParticleSystem.EmissionModule em;
    private AudioSource audio;
	private Rigidbody2D rb;
	private float acc = 0.1f;
	private float rotOverTime = 0f;


	// Use this for initialization
	void Start () {
        audio = GetComponent<AudioSource>();
		rb = GetComponent<Rigidbody2D>();
		Physics2D.gravity = Vector2.zero;
		//part = GameObject.Find ("death_crush1").GetComponent<ParticleSystem>();
		//em = part.emission;
	}
	
	// Update is called once per frame
	void Update () {
		rotOverTime += Time.deltaTime;

        rb.AddForce(new Vector3(-1, 0, 0), ForceMode2D.Force);
		rb.MoveRotation (50.0f * rotOverTime);
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		Debug.Log ("HI");
		if (other.tag == "Player") {
            var playerscript = other.gameObject.GetComponent<Player>();
            playerscript.DealDamage(5);
            if(!audio.isPlaying)
                audio.Play();
            //em.enabled = true;
            //other.GetComponent<SpriteRenderer> ().enabled = false;
            //SceneManager.LoadScene("BeansJamScene");
            this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
		}
	}
}
