﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaBoss : MonoBehaviour {
    public GameObject player;
    public float speed;
    public float attackRange;
    public bool walking;
    public Animator anim;
    public float cooldown;
    public bool cooling;
    public GameObject armHitbox;
    public GameObject hpBar;
    public GameObject hpBarParent;

    public GameObject minion;
    public Vector3[] minionLoc;
    public int minionCooldown;
    public bool canSpawnMinion;

    void Start ()
    {
        hpBarParent.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            Think();
        }
        else
        {
            GetPlayer();
        }
    }

    public void GetPlayer()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void Think()
    {
        if (canSpawnMinion)
        {
            SummonMinion();
        }
        float dist = Vector3.Distance(player.transform.position, transform.position);
        if (!cooling)
        {
            if (dist < attackRange * 2)
            {
                if(dist > attackRange)
                {
                    anim.SetBool("Walk", false);
                    anim.SetTrigger("Slam");
                    cooling = true;
                    StartCoroutine(Cooldown());
                }
            }
        }
        if (dist > attackRange)
        {
            Move();
            if (!walking)
            {
                walking = true;
                anim.SetBool("Walk", true);
            }
        }
        else
        {
            walking = false;
            anim.SetBool("Walk", false);
            if (!cooling)
            {
                cooling = true;
                StartCoroutine(Cooldown());
                Attack();
            }
        }
    }

    public void Move()
    {
        Vector3 lookPos = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
        transform.LookAt(lookPos);
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed);
    }
    public void Attack()
    {
        anim.SetTrigger("Punch");
    }
    public void AttackHitOn()
    {
        armHitbox.SetActive(true);
    }
    public void AttackHitOff()
    {
        armHitbox.SetActive(false);
    }

    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(cooldown);
        cooling = false;
    }

    public void SummonMinion()
    {
        for (int i = 0; i < 2; i++)
        {
            GameObject newMinion = Instantiate(minion, minionLoc[i], minion.transform.rotation) as GameObject;
            newMinion.GetComponent<Lava_Elemental>().GetPlayer(player);
        }
        canSpawnMinion = false;
        StartCoroutine(CoolMinions());
    }

    IEnumerator CoolMinions()
    {
        yield return new WaitForSeconds(minionCooldown);
        canSpawnMinion = true;
    }

}