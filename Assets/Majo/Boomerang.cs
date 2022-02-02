using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boomerang : MonoBehaviour
{
    [SerializeField] float speed = 5, distance=10;
    Rigidbody rb;
    Vector3 shootPos;

    private void Awake() {
        rb = GetComponent<Rigidbody>();
    }
    void Start()
    {
        GetPos();
        rb.velocity = transform.forward * speed;
        
    }

   
    void Update() {
        Debug.Log("magnitud" + shootPos.magnitude);
        if (shootPos.magnitude == distance) {
           
            rb.velocity = -rb.velocity;
        }
    }
    void GetPos() {
       shootPos = transform.position;
    }
   

    
}
