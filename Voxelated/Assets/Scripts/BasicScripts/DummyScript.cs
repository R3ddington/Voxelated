using UnityEngine;
using System.Collections;

public class DummyScript : MonoBehaviour {
    public Animator anim;
    /*
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    */

    public void Hit ()
    {
        anim.SetTrigger("Hit");
    }
}
