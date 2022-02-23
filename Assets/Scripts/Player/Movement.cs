using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour
{
    public static Action A_Move;
    [Header("Variables Movimiento")]
    [SerializeField] public float speed;
    [Range(-1,1)]
    [SerializeField]private float x_axis, z_axis;
    [SerializeField] ManagerJoystick manager_Joystick;
    public bool running;
    // Start is called before the first frame update

    // Update is called once per frame
    void FixedUpdate()
    {
        x_axis = manager_Joystick.InputHorizontal();
        z_axis = manager_Joystick.InputVertical();
        if (x_axis != 0 || z_axis != 0)
        {
            Change_Pos(x_axis, z_axis);
        }
        else running = false;
    }
    public void Change_Pos(float x, float z)
    {
        running = true;
        Vector3 force = new Vector3(x, 0, z);
        transform.position += force * speed*Time.deltaTime;

        A_Move?.Invoke();
    }
}
