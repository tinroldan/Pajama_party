using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoomerang : MonoBehaviour
{
    public delegate void Actions();
    public event Actions Shooted;
        
    [SerializeField]float speed = 5;
    Boomerang myBoomerang;
    private void Awake() {
        myBoomerang = GetComponentInChildren<Boomerang>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void shoot() {
        myBoomerang.transform.position = myBoomerang.originalPos.position;
        myBoomerang.gameObject.SetActive(true);
        myBoomerang.transform.SetParent(null, true);
        myBoomerang.shootPos = transform.position;
        myBoomerang.rb.AddForce(transform.forward * speed);
        if (Shooted != null) Shooted();
        
    }
}
