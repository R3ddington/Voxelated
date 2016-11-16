using UnityEngine;
using System.Collections;

public class OpenChest : MonoBehaviour {
    public Animator anim;
    public int type;
    public Transform particlePos;
    public GameObject particle;

	public void Interact ()
    {
        anim.SetTrigger("Open");
        Effect();
    }

    public void Effect ()
    {
        switch (type)
        {
            case 0:
                Instantiate(particle, particlePos.position, Quaternion.identity);
                break;
        }
    }
}
