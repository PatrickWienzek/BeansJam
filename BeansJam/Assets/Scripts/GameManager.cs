using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    private string _selectedCharacter;
    private bool _isSelected = false;
    public GameObject bohne;
    public GameObject bohne_budi;
    public GameObject bohne_eddie;
    public GameObject bohne_laser;
    public GameObject bohne_nils;
    public GameObject bohne_simon;
    public GameObject bohne_leonie;

    public Vector3 StartPosition = new Vector3(-89.1f, 60.5f, 0);

    [HideInInspector]
    public GameObject _player;
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
                    _player = (GameObject)Instantiate(bohne, StartPosition, Quaternion.identity);
                else if (_selectedCharacter.Equals(bohne_budi.name))
                    _player = (GameObject)Instantiate(bohne_budi, StartPosition, Quaternion.identity);
                else if (_selectedCharacter.Equals(bohne_eddie.name))
                    _player = (GameObject)Instantiate(bohne_eddie, StartPosition, Quaternion.identity);
                else if (_selectedCharacter.Equals(bohne_laser.name))
                    _player = (GameObject)Instantiate(bohne_laser, StartPosition, Quaternion.identity);
                else if (_selectedCharacter.Equals(bohne_nils.name))
                    _player = (GameObject)Instantiate(bohne_nils, StartPosition, Quaternion.identity);
                else if (_selectedCharacter.Equals(bohne_simon.name))
                    _player = (GameObject)Instantiate(bohne_simon, StartPosition, Quaternion.identity);
                else if (_selectedCharacter.Equals(bohne_leonie.name)) {
                    _player = (GameObject)Instantiate(bohne_leonie, StartPosition, Quaternion.identity);
                }

                _player.tag = "Player";

            }
        }
	}

    public void SetCharacter(string selected)
    {
        _selectedCharacter = selected;
    }
}
