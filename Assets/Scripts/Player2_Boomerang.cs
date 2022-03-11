using UnityEngine;
using UnityEngine.UI;

public class Player2_Boomerang : MonoBehaviour {
    
    [SerializeField] public Test_boomerang myBoomerang;
    int score;
    bool alive;
    Text myText;
    CapsuleCollider myCollider;
    Movement mov;
   
  
    void Start() {
        myCollider = GetComponent<CapsuleCollider>();
        alive = true;
        myBoomerang.target = transform;
        mov = GetComponent<Movement>();
    }

    public void Shoot() {
       
        if (myBoomerang.shooted || !gameObject.activeSelf) return;
        myBoomerang.gameObject.SetActive(true);
        
        myBoomerang.Throw();
        managerSound manager = GameObject.Find("MainSound").GetComponent<managerSound>();
        manager.soundShoot();

    }
    private void OnCollisionEnter(Collision other) {
        if (other.gameObject != myBoomerang.gameObject && other.gameObject.CompareTag("Boomerang")) {
            if (mov.shieldActive)
            {
                return;
            }
            else
            {
                myCollider.enabled = false;

                AnimatorController anim = GetComponent<AnimatorController>();
                anim.Die();
                alive = false;

                // Modificaci n Jose
                managerSound manager = GameObject.Find("MainSound").GetComponent<managerSound>();
                manager.soundDie();
                //Hasta ac  

            }

        }
    }
}
