using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRobotRocket : MonoBehaviour {

    public float detectDist;
    public bool targeting;
    public GameObject player;
    public float maxDist;
    public bool dead;
    public float speed;
    public int attackCooldown;
    public bool cooling;
    public GameObject rocket;
    public GameObject[] rocketPos;
    public GameObject target;

	// Use this for initialization
	void Start () {
        SetUp();
	}
	
	// Update is called once per frame
	void Update () {
        if (!dead)
        {
            if(player != null)
            {
                if (!targeting)
                {
                    Target();
                }
                else
                {
                    Move();
                }
            }
        }
	}

    public void SetUp()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if(player == null)
        {
            StartCoroutine(WaitForRetry());
        }
    }
    IEnumerator WaitForRetry()
    {
        yield return new WaitForSeconds(1);
        SetUp();
    }

    public void Target()
    {
        float dist = Vector3.Distance(transform.position, player.transform.position);
        if(dist < detectDist)
        {
            print("Found target");
            targeting = true;
        }
    }

    public void Move()
    {
        float dist = Vector3.Distance(transform.position, player.transform.position);
        transform.LookAt(player.transform);
        if (dist > maxDist)
        {
            //  transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed);
            transform.Translate(Vector3.forward * speed);
           // transform.Translate(Vector3.MoveTowards(transform.position, player.transform.position, speed));
        }
        else
        {
            if(!cooling)
            {
                Attack();
            }
        }
    }
    public void Attack()
    {
        cooling = true;
        int p = Random.Range(0, 2);
        target = player;
        GameObject newRocket = Instantiate(rocket, rocketPos[p].transform.position, rocket.transform.rotation) as GameObject;
        newRocket.GetComponent<HostileRocket>().target = target;
        StartCoroutine(RocketCooldown());
    }
    IEnumerator RocketCooldown()
    {
        yield return new WaitForSeconds(attackCooldown);
        cooling = false;
    }
}
