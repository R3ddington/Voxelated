using UnityEngine;
using System.Collections;

public class BossDoor : MonoBehaviour {

    public bool hasKey;
    public Animator anim;

    public int type;
    public GameObject boss;

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
            switch (type)
            {
                case 0:
                    boss.GetComponent<TreantBoss>().StartBattle();
                    break;
            }
        }
        else
        {
            //SHOW ITS LOCKED TEXT
        }
    }
}
