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
    [SerializeField] ManagerJoystick manager_Joystick;
    private float tpDistance = 5;
    [SerializeField] private GameObject Shield;
    [Header("VFX")]
    [SerializeField] ParticleSystem ShieldPS;
    // Start is called before the first frame update

    // Update is called once per frame
    void FixedUpdate()
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
        transform.position += force * speed*Time.deltaTime;

        A_Move?.Invoke();
    }
    public IEnumerator SpeedPowerUp()
    {
        speed = speed * 2;
        yield return new WaitForSeconds(5f);
        speed = speed / 2;
    }

    public void TeleportPowerUp()
    {
        transform.position += transform.forward * tpDistance;
    }

    public void ShieldPowerUp()
    {
        Shield.SetActive(true);
        ShieldPS.gameObject.SetActive(true);
        ShieldPS.Play();
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Boomerang")
        {
            Shield.SetActive(false);
            ShieldPS.Stop();
        }
    }
}
