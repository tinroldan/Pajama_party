using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boomerang : MonoBehaviour
{
    [SerializeField] float speed = 5;
    Rigidbody rb;
    Vector3 shootPos,dir;
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
        
    }
    void Follow() {
        dir = originalPos.position-transform.position;
        Debug.Log(dir.magnitude);
        // transform.position += (transform.position - originalPos * -speed) * Time.deltaTime;
        rb.MovePosition(transform.position + (dir *10* Time.deltaTime));
        if (dir.magnitude <= 0.1f) {
            Debug.Log("Hola");
            rb.velocity = Vector3.zero;
            shooted = false;
            returnB = false;
        }
        //< >
    }



}
