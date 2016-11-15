using UnityEngine;
using System.Collections;

public class OpenChest : MonoBehaviour {
    public Animator anim;

	public void Interact ()
    {
        anim.SetTrigger("Open");
    }
}
