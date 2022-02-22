using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_boomerang : MonoBehaviour {
    [SerializeField] float speed, inicialSpeed;
    public Rigidbody rb;
    public Transform target, spawn;
    float time;

    bool back,  reflect=false;
    public bool shooted;


    float distance;
    // Start is called before the first frame update

    private void Awake() {
        rb = GetComponent<Rigidbody>();
        inicialSpeed = speed;
        gameObject.SetActive(false);
    }


    // Update is called once per frame
    private void Update() {
        


        if (shooted) {
            distance = Vector3.Distance(target.position, transform.position);
            //if (!reflect && !back) {
            //    transform.eulerAngles = target.transform.localEulerAngles;
            //    print("hotatatata");
            //}
            transform.position += transform.forward * speed * Time.deltaTime;
            print("Estpy avanzando");
          
        }
        if ((reflect || distance > 15) && !back) {
            print("reflejo");
            if (speed <= 0) {
                Return();
            }
            speed -= 0.1f;
        }
        if (back) {
            if (speed < inicialSpeed) {
                speed += 0.1f;
                print("back");

            }
            if (distance <= 5) {
                PickUp();
                return;
            }
            if (reflect) {
                time += Time.deltaTime;
                if (time >= 0.5f) {
                    reflect = false;
                    time = 0;
                }
                return;
            }
            print("mirar");
            transform.LookAt(target);
        }

    }
   
    public void Throw() {
        transform.SetParent(null);
        transform.eulerAngles = spawn.eulerAngles;
        print("Angulos: " + transform.eulerAngles);
        back = false;
        shooted = true;
    }
    void Return() {
        back = true;
    }
    void PickUp() {
        print("recogiendo");
        shooted = false;
        back = false;
        reflect = false;
        transform.SetParent(spawn);
        gameObject.transform.eulerAngles = spawn.eulerAngles;
        transform.position = spawn.position;
        gameObject.SetActive(false);
    }
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject != target.gameObject) {
            Return();
            reflect = true;
            print("Estoy chocando");
            if (transform.eulerAngles.y < 15 || transform.eulerAngles.y > 315 || (transform.eulerAngles.y >= 135 &&
                transform.eulerAngles.y <= 225)) {
                transform.eulerAngles = new Vector3(0, Mathf.PI - transform.eulerAngles.y + 180, 0);

            } else {
                transform.eulerAngles = new Vector3(0, 2 * Mathf.PI - transform.eulerAngles.y, 0);
            }
            //transform.eulerAngles.y = -transform.position + 2 * Vector3.Dot( transform.position,collision.GetContact(0).normal) * collision.GetContact(0).normal;

        }
    }
   

    //void LookAtPlayer() {
    //    Vector3 direction = target.position - transform.position;
    //    Quaternion toRotation = Quaternion.LookRotation( direction);
    //    transform.rotation = Quaternion.Lerp(transform.rotation,toRotation,speedRotation*Time.deltaTime);
    //}
}
