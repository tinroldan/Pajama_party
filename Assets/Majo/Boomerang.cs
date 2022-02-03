using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boomerang : MonoBehaviour
{
    [SerializeField] float speed = 5;
    Rigidbody rb;
    Vector3 shootPos;
    [SerializeField]Transform originalPos, maxPos;
    Transform pos ;
    bool returnB=false, shooted=false;
    

    private void Awake() {
        rb = GetComponent<Rigidbody>();
        pos = GetComponentInParent<Transform>();
       // originalPos = GetComponentInParent<Transform>().position;
       
    }
    void Start()
    {
       
    }

   
    void Update() {
        if (Input.GetKeyDown(KeyCode.Mouse0)) {
            shoot();
        }
        if(shooted ==true) GoandReturn();
    }
   

    void shoot() {
        pos.SetParent(null, true);
        shootPos=transform.position;
        rb.AddForce(transform.forward * speed);
        shooted = true;
    }

    void GoandReturn() {
       
        if (returnB==false && Vector3.Distance(maxPos.position,transform.position) <= 10 ) {
            //rb.AddForce(-transform.forward * speed);
            rb.velocity = Vector3.zero;          
            returnB = true;
        } else if (returnB) {
            Follow();
        }
        if (transform.position.z <= shootPos.z) {
           // rb.velocity = Vector3.zero;
        }
    }
    void Follow() {
        Vector3 dir = originalPos.position-transform.position;
        // transform.position += (transform.position - originalPos * -speed) * Time.deltaTime;
        rb.MovePosition(transform.position + (dir *10* Time.deltaTime));
       
       // rb.AddForce (dir * speed* Time.deltaTime);
    }



}
