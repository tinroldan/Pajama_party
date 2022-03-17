using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class managerSound : MonoBehaviour
{
    Movement mov;
    ManagerJoystick mj;
    public AudioSource dieSound;
    public AudioSource soundMovement;
    public AudioSource soundShooting;
    public AudioSource soundRebote;
    public AudioSource soundButtonSettings;
  
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void soundBoton()
    {
        
    }

    public void soundDie ()
    {
        
        if(dieSound.isPlaying == false)
        {
            dieSound.Play();
        }
    }

    public void soundMove()
    {
        /* if(soundMovement.isPlaying == false)
        {
            soundMovement.Play();
        }
        */
        soundMovement.Play();
        
    }


    public void soundShoot()
    {
        soundShooting.Play();
        
    }

    public void soundReboting()
    {
        soundRebote.Play();
    }

    public void buttonSettings()
    {
        soundButtonSettings.Play();
    }

    
    
}
