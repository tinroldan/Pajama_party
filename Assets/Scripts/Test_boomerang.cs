using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_boomerang : MonoBehaviour
{
    [SerializeField] float speed, inicialSpeed;
    public Rigidbody rb;
    public Transform target, spawn;


    bool back, shooted;
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
        if (distance > 15 && !back) {

            if(speed <= 0) {
                Return();
            }
            speed -= 0.1f;
        }
        if (back) {
            if (speed< inicialSpeed) {
                speed += 0.1f;
            }if(distance <= 2) {
                PickUp();
            }
            transform.LookAt(target);
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
        transform.SetParent(spawn);
        gameObject.transform.eulerAngles =Vector3.zero;
        transform.position = spawn.position;
        gameObject.SetActive(false);
    }


    //void LookAtPlayer() {
    //    Vector3 direction = target.position - transform.position;
    //    Quaternion toRotation = Quaternion.LookRotation( direction);
    //    transform.rotation = Quaternion.Lerp(transform.rotation,toRotation,speedRotation*Time.deltaTime);
    //}
}
