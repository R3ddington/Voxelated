using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava_Elemental : MonoBehaviour {

    public Vector3[] idleWaypoints;
    public int amount;
    public int targetNumber;
    public Vector3 target;
    public GameObject player;
    public bool targetPlayer;
    public float speed;
    public int attackTimer;
    public bool cooling;
    public float attackCooldown;
    public float attackRange;
    public Animator anim;

    void Start ()
    {
        NextWayPoint();
        if(anim == null)
        {
            anim = GetComponent<Animator>();
        }
    }

	// Update is called once per frame
	void Update () {
        if (!targetPlayer)
        {
            IdleFloating();
        }
        else
        {
            TargetPlayer();
        }
	}

    public void GetPlayer(GameObject p)
    {
        player = p;
        targetPlayer = true;
    }

    void IdleFloating()
    {
        Move();
        if (transform.position == target) //WERKT SOMS NIET
        {
            NextWayPoint();
        }
        else if (transform.position.ToString() == target.ToString()) //WERKT ALTIJD
        {
            NextWayPoint();
        }
    }
    void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed);
    }
    void NextWayPoint()
    {
        //   print("Setting New Waypoint");
        if (targetNumber == amount)
        {
            targetNumber = 0;
        }
        else
        {
            targetNumber++;
        }
        target = idleWaypoints[targetNumber];
        IdleFloating();
    }

    void TargetPlayer()
    {
        target = player.transform.position;
        float distance = Vector3.Distance(target, transform.position);
        if (distance < attackRange)
        {
            if (!cooling)
            {
                cooling = true;
                anim.SetTrigger("Attack");
                StartCoroutine(AttackCoolDown());
            }
        }
        else
        {
            Move();
        }
    }
    IEnumerator AttackCoolDown()
    {
        yield return new WaitForSeconds(attackCooldown);
        cooling = false;
    }
}
