using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boomerang : MonoBehaviour
{
    [SerializeField] float speed = 5, distance=10;
    Rigidbody rb;
    Vector3 shootPos,dir;
    [SerializeField]Transform originalPos;
   
    bool returnB=false, shooted=false;
    

    private void Awake() {
        rb = GetComponent<Rigidbody>();
        
       
    }
    private void FixedUpdate() {
        Turn();
    }

    void Update() {        
       
        if(shooted ==true) GoandReturn();
    }
   

    public void shoot() {
        transform.SetParent(null, true);       
        shootPos =transform.position;
        rb.AddForce(transform.forward * speed);
        shooted = true;
        returnB = false;
    }

    void GoandReturn() {
        Turn();
        if (returnB==false && Vector3.Distance(transform.position,shootPos) >= distance ) {
          rb.velocity = Vector3.zero;          
            returnB = true;
        } else if (returnB) {
            Follow();
        }
        
    }
    void Follow() {
        dir = originalPos.position-transform.position;
        rb.MovePosition(transform.position + (dir *20* Time.deltaTime));
        if (dir.magnitude <= 0.1f) {          
            rb.velocity = Vector3.zero;
            shooted = false;
            returnB = false;
            transform.SetParent(originalPos,true);
        }
        
    }
     void Turn() {
        //rb.AddTorque(Vector3.up);
       // rb.angularVelocity = new Vector3(0, 7, 0);
     }



}
