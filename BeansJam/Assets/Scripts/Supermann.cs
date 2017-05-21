using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Supermann : MonoBehaviour {


    private GameObject _camera;
    private float _timer ;
	// Use this for initialization

    void Start () {
        _timer = Random.Range(60, 350);
    }
	
	// Update is called once per frame
	void Update () {
        Fly();
	}

    void Fly()
    {
        _timer -= Time.deltaTime;
        if(_timer <= 0)
        {
            if (_camera == null)
                _camera = GameObject.FindGameObjectWithTag("MainCamera");
            transform.position = Vector3.MoveTowards(transform.position, _camera.transform.position, 0.2f);
            float distance = Vector3.Distance(transform.position, _camera.transform.position);

            if (distance <= 3)
                Destroy(gameObject);
        }
        
    }
}
