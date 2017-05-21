using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class LaserBehavior : MonoBehaviour {
    public float MaxAttackDistance = 15.0f;
    public int NumExplosions = 25;
    public float AttackCoolDown = 1.0f;

    private bool canAttack = true;

    public GameObject Explosion;

    private enum Attack {
        Laserschelle,
        Laserkick
    }

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if(Input.GetKey(KeyCode.E)) {
            var attacks = (Attack[])System.Enum.GetValues(typeof(Attack));
            var attack = attacks[UnityEngine.Random.Range(0, attacks.Length)];

            var nearestPlanet = (
                from planet in GameObject.FindGameObjectsWithTag("Planet")
                let distance = (planet.transform.position - this.transform.position)
                orderby distance.sqrMagnitude
                select planet
            ).FirstOrDefault();

            if((nearestPlanet.transform.position - this.transform.position).sqrMagnitude <= MaxAttackDistance * MaxAttackDistance) {
                // TODO: Play attack animation/s
                if(attack == Attack.Laserkick) {
                    // TODO: PATRICK
                    GetComponentInChildren<Animator>().SetBool("eduardlaserkick", true);
                    //GetComponentInChildren<Animator>().SetBool("eduardlaserkick", false);
                } else if(attack == Attack.Laserschelle) {
                    // TODO: PATRICK
                    GetComponentInChildren<Animator>().SetBool("eduardlaserschelle", true);
                    //GetComponentInChildren<Animator>().SetBool("eduardlaserschelle", false);
                }

                for(var i = 0; i < NumExplosions; i++) {
                    var offset = UnityEngine.Random.insideUnitCircle * nearestPlanet.GetComponent<CircleCollider2D>().radius * nearestPlanet.transform.localScale.y;
                    Destroy(
                        Instantiate(
                            Explosion,
                            nearestPlanet.transform.position + new Vector3(offset.x, offset.y, 0),
                            Quaternion.AngleAxis(UnityEngine.Random.Range(0, 360), Vector3.forward)
                        ), 1.08333f
                    );
                }

                canAttack = false;
                StartCoroutine(CoolDown(nearestPlanet));
            }
        }
    }

    private IEnumerator CoolDown(GameObject planet) {
        yield return new WaitForSeconds(this.AttackCoolDown / 2.0f);

        planet.SetActive(false);

        yield return new WaitForSeconds(this.AttackCoolDown / 2.0f);

        canAttack = true;
        GetComponent<Player>().OnDestroyPlanet();
        //Destroy(planet);
    }
}
