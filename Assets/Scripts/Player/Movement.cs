using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour
{
    public static Action A_Move;
    [Header("Variables Movimiento")]
    [SerializeField] private float speed;
    [Range(-1,1)]
    [SerializeField]private float x_axis, z_axis;
    public static float direction;
    private Rigidbody rg;
    [SerializeField] ManagerJoystick manager_Joystick;
    // Start is called before the first frame update

    // Update is called once per frame
    private void Start()
    {
        rg = GetComponent<Rigidbody>();
    }
    void Update()
    {
        x_axis = manager_Joystick.InputHorizontal();
        z_axis = manager_Joystick.InputVertical();
        if (x_axis != 0 || z_axis !=0)
        {
            Change_Pos(x_axis, z_axis);
        }
    }
    public void Change_Pos(float x, float z)
    {
        Vector3 force = new Vector3(x, 0, z);
        rg.AddForce(force*speed);
        A_Move?.Invoke();
    }
}
