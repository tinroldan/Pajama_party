using UnityEngine;
using UnityEngine.UI;

public class Player2_Boomerang : MonoBehaviour {
    
    [SerializeField] public Test_boomerang myBoomerang;
    int score;
    Text myText;
    Rigidbody rbBoomerang;
    // Start is called before the first frame update
    void Start() {
        rbBoomerang = myBoomerang.rb;
        myBoomerang.target = transform;
    }

    public void Shoot() {
       
        if (myBoomerang.shooted || !gameObject.activeSelf) return;
        myBoomerang.gameObject.SetActive(true);
        myBoomerang.Throw();
    }
    private void OnTriggerEnter(Collider other) {   //TEMPORAL

        if (other.gameObject != myBoomerang.gameObject && other.gameObject.CompareTag("Boomerang")) {
            gameObject.SetActive(false);
            score += 1;
            if (gameObject.name == "Player (2)") {
                myText.text = score.ToString();
            } else {
                //secondText.text = score.ToString();
            }
            Invoke("Reapear", 5);
        }

    }
    void Reapear() {//TEMPORAL
        gameObject.SetActive(true);
    }



}
