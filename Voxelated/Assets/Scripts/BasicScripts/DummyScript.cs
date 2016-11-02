using UnityEngine;
using System.Collections;

public class DummyScript : MonoBehaviour {
    public Animator anim;
    public int health;

    public void Hit (int i)
    {
        health -= i;
        if (health <= 0)
        {
            //Play death animation
            Destroy(gameObject);
        }
        else
        {
            anim.SetTrigger("Hit");
        }
    }
}
