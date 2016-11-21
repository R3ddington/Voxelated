using UnityEngine;
using System.Collections;

public class TreantBoss : MonoBehaviour {
    public int health;
    public int maxHealth;
    public GameObject hpBar;
    public Animator anim;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
	}

    /*
	// Update is called once per frame
	void Update () {
	
	}
    */
    public void Hit(int i)
    {
        health -= i;
        hpBar.transform.GetComponent<LifeBar>().Damage(maxHealth, i);
        if (health <= 0)
        {
            //Play death animation
            //   Destroy(gameObject);
            anim.SetBool("Death", true);
        }
    }
}
