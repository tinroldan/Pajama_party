using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundMusic : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] soundtrackArray;

    AudioClip RandomClip()
    {
        return soundtrackArray[Random.Range(0, soundtrackArray.Length)];
    }
    // Start is called before the first frame update
    void Start()
    {
        audioSource.PlayOneShot(RandomClip());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
