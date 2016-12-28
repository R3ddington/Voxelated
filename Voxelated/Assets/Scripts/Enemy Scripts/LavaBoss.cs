using System.Collections;
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
}