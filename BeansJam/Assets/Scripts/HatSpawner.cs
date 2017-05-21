using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatSpawner : MonoBehaviour {

    private float _time;
    private float _timer;
    private bool _spawnPowerup = true;
    private Player _player;
	// Use this for initialization
	void Start () {
        _time = Random.Range(40, 60);
        _timer = 0;
    }
	
	// Update is called once per frame
	void Update () {
        if(!_spawnPowerup)
        {
            _timer += Time.deltaTime;
            if(_timer >= _time)
            {
                
                gameObject.GetComponent<Renderer>().enabled = true;
                gameObject.GetComponent<CircleCollider2D>().enabled = true;
                _timer = 0;
                _spawnPowerup = true;
            }
        }
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Player")
            return;

        if(_player == null) {
            _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        }

        var currentHat = _player.Hat;
        Hat hat;

        do {
            hat = Hat.AllHats[Random.Range(0, Hat.AllHats.Count)];
        } while(hat == currentHat);

        _player.ApplyHat(hat);


        _spawnPowerup = false;
        gameObject.GetComponent<CircleCollider2D>().enabled = false;
        gameObject.GetComponent<Renderer>().enabled = false;
    }
}
