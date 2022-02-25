using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    [SerializeField] private ManagerJoystick managerJoystick;
    private Transform player;
    private Vector2 direction;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        direction.x = managerJoystick.InputHorizontal();
        direction.y = managerJoystick.InputVertical();
        if (direction!= Vector2.zero)
        {
            float angle = Mathf.Atan2(direction.y - Vector2.zero.y, direction.x - Vector2.zero.x);
            player.rotation = Quaternion.Euler(0f, 90- angle*Mathf.Rad2Deg, 0f);
        }
    }
}
