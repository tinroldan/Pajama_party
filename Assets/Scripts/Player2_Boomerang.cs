using UnityEngine;
using UnityEngine.UI;

public class Player2_Boomerang : MonoBehaviour {
    [SerializeField] GameObject backgroundBlack;
    [SerializeField] public Test_boomerang myBoomerang;
    int score;
    bool alive;
    Text myText;
    CapsuleCollider myCollider;
   
  
    void Start() {
        myCollider = GetComponent<CapsuleCollider>();
        alive = true;
        myBoomerang.target = transform;
    }

    public void Shoot() {
       
        if (myBoomerang.shooted || !gameObject.activeSelf) return;
        myBoomerang.gameObject.SetActive(true);
        myBoomerang.Throw();
    }
    private void OnCollisionEnter(Collision other) {
        if (other.gameObject != myBoomerang.gameObject && other.gameObject.CompareTag("Boomerang")) {
            myCollider.enabled = false;

            AnimatorController anim = GetComponent<AnimatorController>();
            anim.Die();
            alive = false;
            backgroundBlack.SetActive(true);
            
           
          
        }
    }
    



}
