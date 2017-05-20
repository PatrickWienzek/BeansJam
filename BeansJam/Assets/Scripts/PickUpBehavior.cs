using UnityEngine;

public class PickUpBehavior : MonoBehaviour {

    private float alpha;
    private bool pickedUp;

    public float angularVelocity = Mathf.PI / 2.0f;
    public float linearVelocity = 2.0f;
    public float pickUpDistance = 0.75f;


    private float PickUpSq {
        get { return pickUpDistance * pickUpDistance; }
    }

    private float distance;

    private GameObject player;

	void Start () {
        var x = this.transform.localPosition.x;
        var z = this.transform.localPosition.z;

        this.distance = Mathf.Sqrt(x * x + z * z);
        this.alpha = Mathf.Atan2(z, x);

        this.player = GameObject.FindGameObjectWithTag("Player");
	}
	
	void Update () {
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
                // Apply power up
                this.gameObject.SetActive(false);
            } else {
                this.transform.position += delta;
            }
        }
	}
}
