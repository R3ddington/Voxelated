using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BossDoor : MonoBehaviour {

    public bool hasKey;
    public Animator anim;

    public int type;
    public GameObject boss;
    public GameObject showTextObject;
    public Text showText;
    public AudioSource aSource;

    public void Start ()
    {
        anim = this.GetComponent<Animator>();
    }

	public void CheckDoor()
    {
        if (hasKey)
        {
            anim.SetTrigger("Open");
            aSource.Play();
            switch (type)
            {
                case 0:
                    boss.GetComponent<TreantBoss>().StartBattle();
                    break;
            }
        }
        else
        {
            showTextObject.SetActive(true);
            showText.text = "The door is locked!";
        }
    }
}
