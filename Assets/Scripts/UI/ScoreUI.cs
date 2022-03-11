using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
     GameObject[] points= new GameObject[5];
    [SerializeField] GameObject reference;
    [SerializeField] Sprite paw;
   [SerializeField] Score scoreScript;
    

   
    private void Start() {
       
        for (int i = 0; i < points.Length; i++) {
            points[i] = Instantiate(reference,transform);
            
        }
        for (int i = 0; i < scoreScript.myScore; i++) {
            points[i].GetComponent<Image>().sprite = paw;
            points[i].GetComponent<RectTransform>().localScale = new Vector3(1.5f, 1.5f, 1);
        }
    }
   
}
