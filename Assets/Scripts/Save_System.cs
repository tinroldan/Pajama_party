using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Save_System : MonoBehaviour
{
  
   
    [SerializeField] Online_skin skinOnline, skinPlayer1, skinPlayer2;
   
    void Start() {
        
       LoadCharacter();
    }

     
    public void LoadCharacter() {
        if (Save_Manager.saveM_instance.activeSave.online) {
            skinOnline.LoadCharacter(Save_Manager.saveM_instance.activeSave.onlineCharacter);
        } else {
            skinPlayer1.LoadCharacter(Save_Manager.saveM_instance.activeSave.character_1);
            skinPlayer2.LoadCharacter(Save_Manager.saveM_instance.activeSave.character_2);
        }
       
        
    }
}
