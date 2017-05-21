using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

public class PickUpBehavior : MonoBehaviour {

    private float alpha;
    private bool pickedUp;

    public float angularVelocity = Mathf.PI / 2.0f;
    public float linearVelocity = 2.0f;
    public float pickUpDistance = 0.75f;
    public float fuelAmount = 5.0f;
    public float CoolDownInSeconds = 45.0f;

    private Vector3 startPosition;


    private float PickUpSq {
        get { return pickUpDistance * pickUpDistance; }
    }

    private float distance;

    private GameObject player;
    private bool isGone;

    void Start () {
        this.startPosition = this.transform.localPosition;

        var x = this.transform.localPosition.x;
        var z = this.transform.localPosition.z;

        this.distance = Mathf.Sqrt(x * x + z * z);
        this.alpha = Mathf.Atan2(z, x);
	}
	
	void Update () {
        if(this.isGone) return;

        this.player = this.player ?? GameObject.FindGameObjectWithTag("Player");

        if(this.player == null) return;

        if(!pickedUp) {
            alpha += Time.deltaTime * angularVelocity;
            this.transform.localPosition = new Vector3(
                distance * Mathf.Sin(alpha),
                this.transform.localPosition.y,
                distance * Mathf.Cos(alpha)
            );

            if((player.transform.position - this.transform.position).sqrMagnitude < PickUpSq) {
                pickedUp = true;
            }
        } else {
            var diff = player.transform.position - this.transform.position;
            var delta = diff.normalized * Time.deltaTime;

            if(delta.sqrMagnitude > diff.sqrMagnitude) {
                //this.gameObject.SetActive(false);
                this.GetComponent<SpriteRenderer>().enabled = false;
                this.isGone = true;
                this.pickedUp = false;
                player.GetComponentInChildren<Player>().AddFuel(fuelAmount);

                StartCoroutine(coolDown());
            } else {
                this.transform.position += delta;
            }
        }
	}
    private IEnumerator coolDown() {
        yield return new WaitForSeconds(this.CoolDownInSeconds);

        this.transform.localPosition = this.startPosition;
        this.GetComponent<SpriteRenderer>().enabled = true;
        this.isGone = false;
    }
}
