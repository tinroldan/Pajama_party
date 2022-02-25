using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Focus : MonoBehaviour
{
    public float half_X_bounds, half_Y_bounds, half_Z_bounds;
    public Bounds focusBounds;
    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 position = gameObject.transform.position;
        Bounds bounds = new Bounds();
        bounds.Encapsulate(new Vector3(position.x - half_X_bounds, position.y - half_Y_bounds, position.z - half_Z_bounds));
        bounds.Encapsulate(new Vector3(position.x + half_X_bounds, position.y + half_Y_bounds, position.z + half_Z_bounds));
        focusBounds = bounds;
    }
}
