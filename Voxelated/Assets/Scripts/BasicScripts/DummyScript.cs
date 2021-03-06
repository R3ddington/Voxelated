﻿using UnityEngine;
using System.Collections;

public class DummyScript : MonoBehaviour {
    public Animator anim;
    public int health;
    public int maxHealth;
    public GameObject hpBar;
    public AudioSource aSource;

    public void Hit (int i)
    {
        health -= i;
        hpBar.transform.GetComponent<LifeBar>().Damage(maxHealth, i);
        if (health <= 0)
        {
            //Play death animation
            Destroy(gameObject);
        }
        else
        {
            anim.SetTrigger("Hit");
            aSource.Play();
        }
    }
}
