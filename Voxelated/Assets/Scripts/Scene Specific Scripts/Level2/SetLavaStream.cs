using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetLavaStream : MonoBehaviour {
    public Animator anim;
    public int type;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        anim.SetInteger("Type",type);
	}
}
