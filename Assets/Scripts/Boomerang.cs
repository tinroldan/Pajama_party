using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boomerang : MonoBehaviour
{
    [SerializeField] float speed = 5, distance=10;
    public Rigidbody rb;
    public Vector3 shootPos;
    Vector3 dir;
    [SerializeField] public Transform originalPos;
    PlayerBoomerang myPlayer;
   
    bool returnB=false, shooted=false;
    

    private void Awake() {
        myPlayer = GetComponentInParent<PlayerBoomerang>();
        rb = GetComponent<Rigidbody>();
        myPlayer.Shooted += GetShoot;
        gameObject.SetActive(false);
        
       
    }


    void Update() {        
       
        if(shooted ==true) GoandReturn();
    }
    
    void GetShoot() {
        shooted = true;
    }
   

    //public void shoot() {
    //    transform.SetParent(null, true);       
    //    shootPos =transform.position;
    //    rb.AddForce(transform.forward * speed);
    //    shooted = true;
    //    returnB = false;  PONER CUIDADO, POSIBLE CAUSA DE BUG!!!!!! MIRAR SHOOT EN PLAYERBOOMERANG
    //}

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
            //rb.velocity = Vector3.zero;
            //shooted = false;
            //returnB = false;
            //transform.SetParent(originalPos,true);
            //gameObject.SetActive(false);
        }
        
    }

    private void OnCollisionEnter(Collision collision) {
        if(returnB == true && collision.gameObject == myPlayer.gameObject) {
            rb.velocity = Vector3.zero;
            shooted = false;
            returnB = false;
            transform.SetParent(originalPos, true);
            gameObject.SetActive(false);
        }
    }
    void Turn() {
        //rb.AddTorque(Vector3.up);
       // rb.angularVelocity = new Vector3(0, 7, 0);
     }



}
