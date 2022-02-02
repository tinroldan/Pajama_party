using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boomerang : MonoBehaviour
{
    [SerializeField] float speed = 5, distance=10;
    Rigidbody rb;
    Vector3 shootPos;
    Transform pos;
    

    private void Awake() {
        rb = GetComponent<Rigidbody>();
        pos = GetComponentInParent<Transform>();
    }
    void Start()
    {
        
        shoot();
        
    }

   
    void Update() {

        GoandReturn();
      


    }
    void GetPos() {
       shootPos = transform.position;
    }

    void shoot() {
        pos.SetParent(null, true);
        GetPos();
        rb.AddForce(transform.forward * speed);

    }

    void GoandReturn() {
        if (Vector3.Distance(shootPos, transform.position) >= distance) {
            //rb.AddForce(-transform.forward * speed);
            rb.velocity = -rb.velocity;
        }
        if (transform.position.z <= shootPos.z) {
            rb.velocity = Vector3.zero;
        }
    }



}
