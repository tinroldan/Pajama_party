using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_boomerang : MonoBehaviour {
    [SerializeField] float speed, inicialSpeed;
    public Rigidbody rb;
    public Transform target, spawn;


    bool back, shooted, reflect;
    [SerializeField] float speedRotation;
    float distance;
    // Start is called before the first frame update

    private void Awake() {
        rb = GetComponent<Rigidbody>();
        inicialSpeed = speed;
    }


    // Update is called once per frame
    private void Update() {
        


        if (shooted) {
            distance = Vector3.Distance(target.position, transform.position);
            transform.position += transform.forward * speed * Time.deltaTime;

        }
        if (reflect || distance > 15 && !back) {

            if (speed <= 0) {
                Return();
            }
            speed -= 0.1f;
        }
        if (back) {
            if (speed < inicialSpeed) {
                speed += 0.1f;
            }
            if (distance <= 2) {
                PickUp();
                return;
            }
            //transform.LookAt(target);
            print("moiro");
        }

    }

    public void Throw() {
        back = false;
        shooted = true;
        transform.SetParent(null);
    }
    void Return() {
        back = true;
    }
    void PickUp() {
        back = false;
        transform.SetParent(spawn);
        gameObject.transform.eulerAngles = spawn.rotation.eulerAngles;
        transform.position = spawn.position;
        gameObject.SetActive(false);
    }
    private void OnCollisionEnter(Collision collision) {
        back = true;
        reflect = true;
        print(transform.eulerAngles.y);

        if ( transform.eulerAngles.y < 15 || transform.eulerAngles.y >315 || (transform.eulerAngles.y >=135 && 
            transform.eulerAngles.y <=225)) {
            transform.eulerAngles = new Vector3(0, Mathf.PI - transform.eulerAngles.y+ 180, 0);
            print("MAYOR 360 :" );

        } else {
            transform.eulerAngles = new Vector3(0, 2 * Mathf.PI - transform.eulerAngles.y, 0);
            print("MENOR :");

        }
        print("dESPUES :" +transform.eulerAngles.y);



        //transform.eulerAngles.y = -transform.position + 2 * Vector3.Dot( transform.position,collision.GetContact(0).normal) * collision.GetContact(0).normal;


    }


    //void LookAtPlayer() {
    //    Vector3 direction = target.position - transform.position;
    //    Quaternion toRotation = Quaternion.LookRotation( direction);
    //    transform.rotation = Quaternion.Lerp(transform.rotation,toRotation,speedRotation*Time.deltaTime);
    //}
}
