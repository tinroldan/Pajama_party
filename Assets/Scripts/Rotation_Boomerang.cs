using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation_Boomerang : MonoBehaviour
{
    Test_boomerang test_Boomerang;
    private void Start() {
        test_Boomerang = GetComponentInParent<Test_boomerang>();
    }
    // Update is called once per frame
    void Update()
    {if(test_Boomerang.speed !=0)
        transform.Rotate(new Vector3(700, 0, 0) * Time.deltaTime);
    }
}
