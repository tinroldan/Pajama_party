using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour {
    GameObject[] points = new GameObject[5];
    [SerializeField] GameObject reference;
    [SerializeField] Sprite paw;
    [SerializeField] Score scoreScript;
    [SerializeField] GameObject winner, buttoms;
   

    private void Start() {

        for (int i = 0; i < points.Length; i++) {
            points[i] = Instantiate(reference, transform);

        }


    }
    private void Update() {
        if (gameObject) {
            for (int i = 0; i < scoreScript.myScore; i++) {
                if(scoreScript.myScore >= 6) {//MACHEYTEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE
                    for (int j = 0; j < 5; j++) {
                        points[j].GetComponent<Image>().sprite = paw;
                        points[j].GetComponent<RectTransform>().localScale = new Vector3(1.5f, 1.5f, 1);
                    }
                    break;
                }

                points[i].GetComponent<Image>().sprite = paw;
                points[i].GetComponent<RectTransform>().localScale = new Vector3(1.5f, 1.5f, 1);
            }
            if (scoreScript.myScore >= 5) {
                Map_Manager.winner = true;
                winner.SetActive(true);
                buttoms.SetActive(true);
            }
        }
    }

}
