using UnityEngine;

public class Player2_Boomerang : MonoBehaviour {
    public float force;
    [SerializeField] public Test_boomerang myBoomerang;
    Rigidbody rbBoomerang;
    // Start is called before the first frame update

    void Start() {
        rbBoomerang = myBoomerang.rb;
        myBoomerang.target = transform;
    }
    private void FixedUpdate() {

    }
    public void Shoot() {
        //if (myBoomerang != null) {
        //   rbBoomerang.AddForce(transform.forward * force);
        //    myBoomerang = null;
        //}
        myBoomerang.gameObject.SetActive(true);

        myBoomerang.Throw();
    }
   



}
