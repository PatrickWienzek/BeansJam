using System.Collections;
using System.Linq;
using UnityEngine;

public class Player : MonoBehaviour {

    public int live = 3;
    public float speed = 0.125f;
    public float jumpForce = 55.0f;
    public float MaxFuel = 100.0f;

    private Rigidbody2D _rigidbody;
    private RotationPlanet _planet;
    private GameObject planet;
    public float rotationSpeed = 60.0f;
    public float flyingSpeed = 100;
    private bool _jumpPossible = false;
    private Transform _jumpForcePosition;
    private Transform _planetCore;
    private float _gravity = 5f;
    private GameObject[] enemies;
    private float _extraGrav = 1;
    private float cameraTimer = 0.0f;
    private GameObject background;

    private bool isFlying = false;
    private float fuel = 5.0f;
    public float burnRate = 1.0f;

    public bool InvertControl = false;
    public float ControlFactor {
        get {
            return InvertControl ? -1.0f : 1.0f;
        }
    }

    // Use this for initialization
    void Start() {
        _rigidbody = GetComponent<Rigidbody2D>();
        planet = GameObject.FindGameObjectWithTag("Planet");
        _planet = planet != null ? planet.GetComponent<RotationPlanet>() : null;
        _planetCore = planet != null ? planet.transform.GetChild(0) : null;
        _jumpForcePosition = transform.GetChild(1).transform;
        background = GameObject.Find("Background");
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
    }

    // Update is called once per frame
    void Update() {
        Move();
        var nearestPlanet = (
            from planet in GameObject.FindGameObjectsWithTag("Planet")
            let distance = (planet.transform.position - this.transform.position)
            orderby distance.sqrMagnitude
            select planet
        ).FirstOrDefault();

        var wasFlying = isFlying;
        isFlying = Input.GetKey(KeyCode.LeftShift) && fuel > 1.0f;
        _planet.isJumping(isFlying);
        if(wasFlying && !isFlying) {
            StartCoroutine(TurnCamera(transform.rotation));
        }

        if(!isFlying) {
            var newCore = nearestPlanet.transform.GetChild(0);
            if(newCore != _planetCore) {
                StartCoroutine(TurnCamera(_planetCore.rotation));
                _planetCore = newCore;
            }

            var rotateBy = Input.GetAxis("Horizontal") * ControlFactor * rotationSpeed * Time.deltaTime;
            this.RotateObjects(nearestPlanet, rotateBy);
            Gravity();
        } else {
            var dir = (transform.up * Input.GetAxis("Vertical") * ControlFactor + transform.right * Input.GetAxis("Horizontal") * ControlFactor) * Time.deltaTime * flyingSpeed;
            Debug.DrawRay(transform.position, dir);

            _rigidbody.velocity = dir;
            var burn = Mathf.Min(this.fuel, burnRate * Time.deltaTime);
            this.fuel = Mathf.Max(fuel - burn, 0.0f);
            Debug.LogFormat("Burned {0} fuel: {1} remaining", burn, this.fuel);
        }

        GameObject.FindGameObjectWithTag("UI").GetComponent<Bar>().health = this.fuel / this.MaxFuel;
    }

    public void AddFuel(float fuelAmount) {
        var add = Mathf.Min(fuelAmount, this.MaxFuel - this.fuel);
        this.fuel += add;
        Debug.LogFormat("Added {0} fuel: {1} remaining", add, this.fuel);
    }

    private IEnumerator TurnCamera(Quaternion prev) {
        cameraTimer = 0.25f;

        while(cameraTimer > 0.0f) {
            this.transform.rotation = Quaternion.Lerp(
                prev,
                Quaternion.LookRotation(Vector3.forward, this.transform.position - _planetCore.position),
                1f - 4f * cameraTimer
            );

            cameraTimer -= Time.deltaTime;
            yield return null;
        }

        transform.up = transform.position - _planetCore.position;
    }

    private void RotateObjects(GameObject nearestPlanet, float rotateBy) {
        foreach(var planet in GameObject.FindGameObjectsWithTag("Planet")) {
            _planet = planet.GetComponent<RotationPlanet>();
            _planet.enabled = planet == nearestPlanet;
            _planet.isJumping(isFlying);
            RotateGameObject(nearestPlanet, planet, rotateBy);
        }

        foreach(var enemy in enemies) {
            RotateGameObject(nearestPlanet, enemy, rotateBy);
        }

        //RotateGameObject(nearestPlanet, background, rotateBy);
        background.transform.rotation *= Quaternion.Euler(0, 0, rotateBy);
        background.transform.position = nearestPlanet.transform.position;
    }

    private void RotateGameObject(GameObject rotateAround, GameObject planet, float rotateBy) {
        var diff = planet.transform.position - rotateAround.transform.position;
        var quat = Quaternion.Euler(0, 0, rotateBy);
        diff = quat * diff;
        planet.transform.position = rotateAround.transform.position + diff;
    }

    private void Move() {
        var horizontal = Input.GetAxis("Horizontal") * ControlFactor;
        transform.Translate(horizontal * speed * Time.deltaTime, 0, 0);

        if(horizontal != 0.0f) {
            if(transform.Find("Visuals") != null) {
                transform.Find("Visuals")
                    .transform
                    .localRotation = Quaternion.Euler(0f, horizontal < 0f ? 180f : 0f, 0f);
            }
        }

        if(_jumpPossible) {
            _extraGrav = 0;
            _rigidbody.velocity = Vector3.zero;
        } else if(!isFlying) {
            _extraGrav += Time.deltaTime * 2;
        }

        if(Input.GetKey(KeyCode.Space) && _jumpPossible) {
            _rigidbody.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
            _planet.isJumping(true);
        } else {
            _planet.isJumping(isFlying);
        }
    }


    void Gravity() {

        if(!_jumpPossible) {
            // Gravity towards the Planetcore on the current planet

            transform.position = Vector3.MoveTowards(transform.position, _planetCore.position, _gravity * _extraGrav * Time.deltaTime);

            //transform.up = transform.position - _planetCore.position;
        }

    }


    private void OnCollisionStay2D(Collision2D collision) {
        if(collision.collider) {
            _jumpPossible = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision) {
        if(collision.collider) {
            _jumpPossible = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.collider) {
            GetComponentInChildren<CameraShake>().Shake();
        }
    }
}