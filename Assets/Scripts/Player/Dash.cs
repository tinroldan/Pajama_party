using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Dash : MonoBehaviour
{
    [SerializeField] private float dash_time, dash_speed, initial_speed;
    Rigidbody rg;
    Transform player;
    Movement mov;

    private void Start()
    {
        rg = GetComponent<Rigidbody>();
        player = GetComponent<Transform>();
        mov = GetComponent<Movement>();
    }

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            StartCoroutine(Dash_coroutine());
        }
    }
    IEnumerator Dash_coroutine()
    {
        float start_time = Time.time;
        initial_speed = mov.max_speed;
        mov.max_speed = dash_speed;
        while (Time.time < start_time + dash_time)
        {
            rg.AddForce( player.forward * dash_speed);
            yield return null;
        }
        mov.max_speed = initial_speed;

    }
    public void Star_Dash()
    {
        StartCoroutine(Dash_coroutine());
    }
}
