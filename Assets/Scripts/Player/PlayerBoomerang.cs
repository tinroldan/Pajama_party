using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoomerang : MonoBehaviour {
    public delegate void Actions();
    public event Actions Shooted;

    [SerializeField] float speed = 5;
    public Boomerang myBoomerang;
    private void Awake() {
        myBoomerang = GetComponentInChildren<Boomerang>();

    }
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }
    void NoBoomerang() {
        if (myBoomerang == null) {
            throw new System.Exception("No boomerang");
        }
    } 
   
    public void shoot() {
        if (myBoomerang == null) {
            throw new System.Exception("No boomerang");
            return;
        }
        myBoomerang.transform.position = myBoomerang.originalPos.position;
        myBoomerang.gameObject.SetActive(true);
        myBoomerang.transform.SetParent(null, true);
        myBoomerang.shootPos = transform.position;
        myBoomerang.rb.AddForce(transform.forward * speed);
        if (Shooted != null) Shooted();
        myBoomerang = null;


    }
   

    private void OnCollisionEnter(Collision collision) { 
   
        if( collision.gameObject != myBoomerang.gameObject &&collision.gameObject.CompareTag("Boomerang")) {
            gameObject.SetActive(false);
            Invoke("Reapear", 5);
        }
    }
    void Reapear() {//TEMPORAL
        gameObject.SetActive(true);
    }
}
