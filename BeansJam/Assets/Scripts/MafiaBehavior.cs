using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MafiaBehavior : MonoBehaviour {

    public float CurrentRadius;
    public float Alpha;

    public float OrbitRadius = 15f;
    public float angularVelocity = Mathf.PI / 8f;
    public float linearVelocity = 5.0f;

    private GameObject nearestPlanet;
    private GameObject player;
    private bool hasSpottedPlayer = false;

    void Start () {
        this.player = GameObject.FindGameObjectWithTag("Player");
	}
	
	void Update () {
        nearestPlanet = (
            from planet in GameObject.FindGameObjectsWithTag("Planet")
            let distance = (planet.transform.position - player.transform.position)
            orderby distance.sqrMagnitude
            select planet
        ).FirstOrDefault();

        if(!hasSpottedPlayer) {
            if(nearestPlanet != null) {
                this.CurrentRadius = Difference(nearestPlanet, this.gameObject).sqrMagnitude;
                // Bestes Epsilon ever -----------------------------v
                if(this.CurrentRadius > OrbitRadius * OrbitRadius + 1) {
                    var direction = Difference(nearestPlanet, this.gameObject).normalized;
                    this.gameObject.transform.Translate(direction * this.linearVelocity * Time.deltaTime, Space.World);
                    this.gameObject.transform.right = direction;
                } else {
                    // In Orbit
                    var d = Difference(this.gameObject, nearestPlanet);
                    this.Alpha = Mathf.Atan2(d.y, d.x) - angularVelocity * Time.deltaTime;
                    this.gameObject.transform.position = new Vector3(
                        nearestPlanet.transform.position.x + OrbitRadius * Mathf.Cos(Alpha),
                        nearestPlanet.transform.position.y + OrbitRadius * Mathf.Sin(Alpha),
                        0
                    );
                    this.gameObject.transform.up = d.normalized;
                }
            }
        } else {
            // ...
        }

        Debug.DrawRay(this.transform.position, player.transform.position - this.transform.position);
        var hit = Physics2D.Raycast(this.transform.position, (player.transform.position - this.transform.position).normalized);
        hasSpottedPlayer = hit.collider.gameObject == player;

        
	}

    private Vector3 Difference(GameObject a, GameObject b) {
        return a.transform.position - b.transform.position;
    }
}
