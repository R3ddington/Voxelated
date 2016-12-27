using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeZombie : MonoBehaviour {

    /*
    public Animator treeZombieAnim;
    public float playerInRange;
    public float playerHitable;
    public RaycastHit playerHit;
    public GameObject playerModel;
    public Vector3 rayInsDis;
    public Vector3 playerGrAtRange;
    public GameObject rayOrigin;

    */

    public GameObject player;
    public float speed;
    public float attackRange;
    public bool walking;
    public Animator anim;
    public float cooldown;
    public bool cooling;
    public GameObject armHitbox;

	// Update is called once per frame
	void Update () {
        //  DetectManager();
        if(player != null)
        {
            Think();
        }
	}

    public void SetPlayer(GameObject p)
    {
        player = p;
    }

    public void Think()
    {
        float dist = Vector3.Distance(player.transform.position, transform.position);
        if(dist > attackRange)
        {
            Move();
            if (!walking)
            {
                walking = true;
                anim.SetBool("Walking", true);
            }
        }
        else
        {
            walking = false;
            anim.SetBool("Walking", false);
            if (!cooling)
            {
                cooling = true;
                StartCoroutine(Cooldown());
                Attack();
            }
        }
    }

    public void Move ()
    {
        Vector3 lookPos = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
        transform.LookAt(lookPos);
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed);
    }
    public void Attack ()
    {
        anim.SetTrigger("Melee");
    }
    public void AttackHitOn()
    {
        armHitbox.SetActive(true);
    }
    public void AttackHitOff()
    {
        armHitbox.SetActive(false);
    }

    IEnumerator Cooldown ()
    {
        yield return new WaitForSeconds(cooldown);
        cooling = false;
    }

    /*
    public void DetectManager() {
        Vector3 dir = playerModel.transform.position - rayOrigin.transform.position;
        Debug.DrawRay(rayOrigin.transform.position, dir, Color.red, playerInRange);
        //Debug.DrawRay(rayOrigin.transform.position + rayInsDis, dir, Color.blue, playerInGrAtRange);
        Debug.DrawRay(rayOrigin.transform.position, rayOrigin.transform.forward, Color.green, playerHitable);

        if (Physics.Raycast(rayOrigin.transform.position, dir, out playerHit, playerInRange)) {
            treeZombieAnim.SetBool("GroundAttack", false);
            if (playerHit.transform.tag == "Player") {
                

                }
            }
        }
    */
                
}
