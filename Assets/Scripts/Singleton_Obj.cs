using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton_Obj : MonoBehaviour
{
    [SerializeField] string tag_manager;
    [SerializeField] GameObject gameManager;
    GameObject manager;
    void Awake()
    {
        manager = GameObject.FindGameObjectWithTag(tag_manager);
        if (manager == null)
        {
            Instantiate(gameManager);
        }

    }

}
