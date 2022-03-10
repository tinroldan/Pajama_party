using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton : MonoBehaviour
{
    [SerializeField] string tag;
    [SerializeField] GameObject gameManager;
    GameObject manager;
    void Awake()
    {
        manager = GameObject.FindGameObjectWithTag(tag);
        if (manager == null)
        {
            Instantiate(gameManager);
        }

    }

}
