using System.Collections;
using UnityEngine;

public class CameraShake : MonoBehaviour {

    public float ShakeDuration = 0.1f;
    public float ShakeIntensity = 0.6f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Shake() {
        this.StartCoroutine(this.ShakeImpl());
    }

    private IEnumerator ShakeImpl() {
        var prevPosition = this.transform.position;

        var shakeTimer = this.ShakeDuration;
        while(shakeTimer > 0.0f) {
            var cameraOffset = Random.insideUnitCircle * this.ShakeDuration * shakeTimer;
            this.transform.localPosition += new Vector3(cameraOffset.x, cameraOffset.y, 0.0f);

            shakeTimer -= Time.deltaTime;
            yield return null;
        }

        this.transform.position = prevPosition;
    }
}
