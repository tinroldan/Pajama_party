using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour
{
    public static Action A_Move;
    [Header("Variables Movimiento")]
    [SerializeField] public float speed, max_speed;
    [Range(-1,1)]
    [SerializeField]private float x_axis, z_axis;
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
        float capped_X_velocity = Mathf.Min(Mathf.Abs(rg.velocity.x), max_speed) * Mathf.Sign(rg.velocity.x);
        float capped_z_velocity = Mathf.Min(Mathf.Abs(rg.velocity.z), max_speed) * Mathf.Sign(rg.velocity.z);

        rg.velocity = new Vector3(capped_X_velocity, rg.velocity.y, capped_z_velocity);
    }
    public void Change_Pos(float x, float z)
    {
        Vector3 force = new Vector3(x, 0, z);
        rg.AddForce(force*speed,ForceMode.Impulse);

        A_Move?.Invoke();
    }
}
