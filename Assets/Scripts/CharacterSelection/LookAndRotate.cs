using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAndRotate : MonoBehaviour
{
    public Transform target;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.LookAt(target);
        transform.Translate(Vector3.right * 10 * Time.deltaTime);
    }
}
