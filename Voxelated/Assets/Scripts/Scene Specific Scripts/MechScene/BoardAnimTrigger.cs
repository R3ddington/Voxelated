using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardAnimTrigger : MonoBehaviour {
    public Animator anim;
    void OnTriggerEnter(Collider c)
    {
        if(c.transform.tag == "Board")
        {
            anim.enabled = true;
            anim.SetTrigger("Loop1");
        }
    }
}
