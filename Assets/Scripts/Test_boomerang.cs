using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_boomerang : MonoBehaviour {
    [SerializeField] float speed, speedRotation;
    float inicialSpeed;
    public Rigidbody rb;
    public Transform target, spawn;
    float time, timeBack;
    bool back, reflect = false;
    public bool shooted;
    float distance;


    private void Awake() {
        rb = GetComponent<Rigidbody>();
        inicialSpeed = speed;
        gameObject.SetActive(false);
    }

    private void Update() {
        if (shooted) { //movimiento y distancia
            distance = Vector3.Distance(target.position, transform.position);
            //if (!reflect && !back) {
            //    transform.eulerAngles = target.transform.localEulerAngles;
            //    print("hotatatata");
            //}
            transform.position += transform.forward * speed * Time.deltaTime;
            print("Estpy avanzando");
        }
        if ((reflect || distance > 15) && !back) { //Reflejo            
            if (speed <= 0) {
                Return();
            }
            speed -= 0.1f;
        }
        if (back) {
            timeBack += Time.deltaTime;
            if (timeBack >= 2) { //Restar velocidad y quedarse quieto
                speed -= 0.1f;
                if (speed <= 0) {
                    speed = 0;
                }
                return;
            }
            if (speed < inicialSpeed) { //Se devuelve
                speed += 0.1f;
            }
            if (distance <= 2) {  //Recoge el boomerang
                PickUp();
                return;
            }
            if (reflect) { // tiempo de espera antes de volver a mirar el boomerang
                time += Time.deltaTime;
                if (time >= 0.5f) {
                    reflect = false;
                    time = 0;
                }
                return;
            }
            LookAtPlayer();
            // transform.LookAt(target); // Mirar
        }
    }

    public void Throw() { //Lanzar boomerang
        speed = inicialSpeed;
        transform.SetParent(null);
        transform.eulerAngles = spawn.eulerAngles;
        print("Angulos: " + transform.localEulerAngles);
        back = false;
        shooted = true;
    }
    void Return() {
        back = true;
    }
    void PickUp() { // Recoger boomerang
        timeBack = 0;
        shooted = false;
        back = false;
        reflect = false;
        transform.SetParent(spawn);
        gameObject.transform.eulerAngles = spawn.eulerAngles;
        transform.position = spawn.position;
        gameObject.SetActive(false);
    }


    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject == target.gameObject && back) { // jugador recoge boomerang
            PickUp();
        } else if (collision.gameObject != target.gameObject) { //rebote Boomerang
            Return();
            reflect = true;
            float a = Vector3.Angle(collision.GetContact(0).normal, transform.position);
            // float a = Mathf.Asin( collision.GetContact(0).normal.magnitude/transform.position.magnitude );
            
            print("Estoy chocando" + a);
            
            // transform.rotation= new Quaternion(0, Mathf.Asin(transform.position.magnitude / collision.GetContact(0).normal.magnitude),0,0);
            //transform.rotation = Quaternion.Inverse(transform.rotation);
            //if (transform.eulerAngles.y <= 15 || transform.eulerAngles.y >= 315 || (transform.eulerAngles.y >= 135 &&
            //    transform.eulerAngles.y <= 225)) {
            //    transform.eulerAngles = new Vector3(0, Mathf.PI - transform.eulerAngles.y + 180, 0);
            //} else {
            //    transform.eulerAngles = new Vector3(0, 2 * Mathf.PI - transform.eulerAngles.y, 0);
            //}
            print("Angulos222: " + transform.localEulerAngles);
            //transform.eulerAngles.y = -transform.position + 2 * Vector3.Dot( transform.position,collision.GetContact(0).normal) * collision.GetContact(0).normal;
        }
    }
    void LookAtPlayer() {
        Vector3 direction = target.position - transform.position;
        Quaternion toRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, speedRotation * Time.deltaTime);
    }
}
