using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boomerang : MonoBehaviour
{
    [SerializeField] float  distance=10;
    public Rigidbody rb;
    public Vector3 shootPos;
    Vector3 dir;
    [SerializeField] public Transform originalPos;
    PlayerBoomerang myPlayer;
   
    bool returnB=false;
    

    private void Start() {
       
        myPlayer = GetComponentInParent<PlayerBoomerang>();
        rb = GetComponent<Rigidbody>();
        gameObject.SetActive(false);
        myPlayer.Shooted += machetazo;
         
    }
    void machetazo() {
        StartCoroutine(GoAndReturn());
    }
    void otromachete() {
        Debug.Log("esoy en machete");
        StartCoroutine(Follow());
    }
    
    //public void shoot() {
    //    transform.SetParent(null, true);       
    //    shootPos =transform.position;
    //    rb.AddForce(transform.forward * speed);
    //    shooted = true;
    //    returnB = false;  PONER CUIDADO, POSIBLE CAUSA DE BUG!!!!!! MIRAR SHOOT EN PLAYERBOOMERANG
    //}

     IEnumerator GoAndReturn() {

        int t = 0;
        while (t <= 50) {
            t++;
            if (returnB == false && Vector3.Distance(transform.position, shootPos) >= distance) {
                rb.velocity = Vector3.zero;
                Debug.Log("Hola soy yo");
                StartCoroutine(Follow());
                returnB = true;
                break;
                
            } 
            yield return new WaitForSeconds(0.2f);

        }
    }
   
    IEnumerator Follow() {
        Debug.Log("Estoy siguiendo");
        returnB = true;
        int t = 0;       
        while (t <= 2000) {
            t++;
            dir = originalPos.position - transform.position;
            rb.MovePosition(transform.position + (dir * 40 * Time.deltaTime));
            yield return new WaitForSeconds(0.001f);

        }

    }

    private void OnCollisionEnter(Collision collision) {
        if(returnB == true && collision.gameObject == myPlayer.gameObject) {
            StopAllCoroutines();
            rb.velocity = Vector3.zero;            
            returnB = false;
            transform.SetParent(originalPos,true);
            gameObject.SetActive(false);
            myPlayer.myBoomerang = this;

        } else if (collision.gameObject != myPlayer.gameObject){
            StopCoroutine(GoAndReturn());
            Debug.Log("Me choqué contra algo");          
            rb.velocity = Vector3.Reflect(rb.velocity,collision.GetContact(0).normal);
            Invoke("otromachete", 0.5f);
           
        }
    }
    void Turn() {
       // rb.AddTorque(Vector3.up);
       // rb.angularVelocity = new Vector3(0, 7, 0);
     }

    //void GoandReturn() {
    //    Turn();
    //    if (returnB==false && Vector3.Distance(transform.position,shootPos) >= distance ) {
    //      rb.velocity = Vector3.zero;          
    //        returnB = true;
    //    } else if (returnB) {
    //        Follow();
    //    }

    //}
    //void Follow() {
    //    dir = originalPos.position-transform.position;
    //    rb.MovePosition(transform.position + (dir *20* Time.deltaTime));
    //    if (dir.magnitude <= 0.1f) {          
    //        //rb.velocity = Vector3.zero;
    //        //shooted = false;
    //        //returnB = false;
    //        //transform.SetParent(originalPos,true);
    //        //gameObject.SetActive(false);
    //    }

    //}

}
