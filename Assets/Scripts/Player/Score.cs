using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    Test_boomerang test_Boomerang;
    public int myScore;
    // Start is called before the first frame update
  
    private void Awake() {
        test_Boomerang = GetComponentInChildren<Test_boomerang>();
        test_Boomerang.Score += AddScore;
    }

    public void AddScore() {
        myScore += 1;
    }
}
