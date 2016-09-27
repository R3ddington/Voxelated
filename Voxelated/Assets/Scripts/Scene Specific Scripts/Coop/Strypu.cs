﻿using UnityEngine;
using System.Collections;

public class Strypu : MonoBehaviour {
    public Animator anim;
    bool triggered;
    public GameObject[] turrets;
    public GameObject[] players;
    public int speed;
    public Vector3 target;
    public bool[] active;
    float distance;
    bool cooling;
    public GameObject[] handHitBox;
	// Use this for initialization
	void Start () {
        Targeting();
	}
	
	// Update is called once per frame
	void Update () {
        distance = Vector3.Distance(target, transform.position);
        if(distance > 5)
        {
            Moving();
            if(anim.GetBool("Walk") == false)
            {
                anim.SetBool("Walk", true);
            }
        }
        else
        {
            if (anim.GetBool("Walk"))
            {
                anim.SetBool("Walk", false);
            }
            if (!cooling)
            {
                //Do damage
                anim.SetTrigger("Attack");
                cooling = true;
                StartCoroutine(Cooldown());
            }
        }
	}

    void Targeting()
    {
        /*
        if (!active[0])
        {
            target = turrets[0].transform.position;
            target.y = transform.position.y;
        }
        */
        if (!(turrets[0] == null))
        {
            TargetTurret(0);
        }
        else
        {
            if (!(turrets[1] == null))
            {
                TargetTurret(1);
            }
        }
    }

    void TargetTurret(int i)
    {
        target = turrets[i].transform.position;
        target.y = transform.position.y;
    }

    void Moving()
    {
        transform.LookAt(target);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(1);
        handHitBox[0].SetActive(true);
        handHitBox[1].SetActive(true);
        yield return new WaitForSeconds(3);
        cooling = false;
        handHitBox[0].SetActive(false);
        handHitBox[1].SetActive(false);
        Targeting();
    }
}