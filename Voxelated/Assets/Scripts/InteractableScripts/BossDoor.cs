using UnityEngine;
using System.Collections;

public class BossDoor : MonoBehaviour {

    public bool hasKey;
    public Animator anim;

    public void Start ()
    {
        anim = this.GetComponent<Animator>();
    }

	public void CheckDoor()
    {
        if (hasKey)
        {
            //GO OPEN
            //ACTIVATE BOSS BATTLE
            anim.SetTrigger("Open");
        }
        else
        {
            //SHOW ITS LOCKED TEXT
        }
    }
}
