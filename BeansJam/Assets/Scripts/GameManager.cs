using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    private string _selectedCharacter;
    private bool _isSelected = false;
    public GameObject bohne;
    public GameObject bohne_budi;
    public GameObject bohne_eddie;
    public GameObject bohne_horse;
    public GameObject bohne_laser;
    public GameObject bohne_nils;
    public GameObject bohne_simon;

    private GameObject _player;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(_player == null)
        {
            if (_selectedCharacter != null)
            {
                if (_selectedCharacter.Equals(bohne.name))
                    _player = (GameObject)Instantiate(bohne, new Vector3(0, 11.5f, 0), Quaternion.identity);
                else if (_selectedCharacter.Equals(bohne_budi.name))
                    _player = (GameObject)Instantiate(bohne_budi, new Vector3(0, 11.5f, 0), Quaternion.identity);
                else if (_selectedCharacter.Equals(bohne_eddie.name))
                    _player = (GameObject)Instantiate(bohne_eddie, new Vector3(0, 11.5f, 0), Quaternion.identity);
                else if (_selectedCharacter.Equals(bohne_horse.name))
                    _player = (GameObject)Instantiate(bohne_horse, new Vector3(0, 11.5f, 0), Quaternion.identity);
                else if (_selectedCharacter.Equals(bohne_laser.name))
                    _player = (GameObject)Instantiate(bohne_laser, new Vector3(0, 11.5f, 0), Quaternion.identity);
                else if (_selectedCharacter.Equals(bohne_nils.name))
                    _player = (GameObject)Instantiate(bohne_nils, new Vector3(0, 11.5f, 0), Quaternion.identity);
                else if (_selectedCharacter.Equals(bohne_simon.name))
                    _player = (GameObject)Instantiate(bohne_simon, new Vector3(0, 11.5f, 0), Quaternion.identity);
            }
        }
	}

    public void setCharacter(string selected)
    {
        _selectedCharacter = selected;
    }
}
