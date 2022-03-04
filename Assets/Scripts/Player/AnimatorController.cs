using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    Animator anim;
    Movement mov;
    [Range(0,1)]
    [SerializeField] int animation_type;
    // Start is called before the first frame update
    void Start()
    {
        mov = GetComponent<Movement>();
        anim = GetComponent<Animator>();
        anim.SetInteger("Animation_type", animation_type);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (mov.running) anim.SetBool("Running", true);
        else anim.SetBool("Running", false);
    }
    public void Throw_Anim()
    {
        anim.SetTrigger("Throw");
    }
}
