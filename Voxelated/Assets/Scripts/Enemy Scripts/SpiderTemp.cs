using UnityEngine;
using System.Collections;

public class SpiderTemp : MonoBehaviour {

    public GameObject spiderPrefab;
    public GameObject player;
    public float playerDetLength;
    public Animator anim;
    public float spiderSpeed;
    public float spiderAttackRange;
    public float spiderSpeedAdj;
    public Rigidbody rb;
    public float damage;
    public int health;
    public int maxHealth;
    public GameObject hpBar;
    public bool cooldown;
    public bool dead;
    public GameObject deathParticle;
    public GameObject particlePos;

    public bool targeting;

    public float agroDistance;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        if (!dead)
        {
            playerDetection();
            if (targeting)
            {
                FollowPlayer();
            }
        }
	}

    public void playerDetection() {
        if(player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
        float distance = Vector3.Distance(transform.position, player.transform.position);
        if(distance < agroDistance)
        {
            anim.SetTrigger("Aggro");
            rb.constraints &= ~RigidbodyConstraints.FreezePositionY;
        }
        if (Physics.Raycast(spiderPrefab.transform.localPosition, spiderPrefab.transform.forward, playerDetLength)) {
          //  print("RC1 Works");
            anim.SetBool("OnGround", true);
            //  spiderPrefab.transform.Translate(spiderPrefab.transform.forward * spiderSpeed);
            if(Physics.Raycast(spiderPrefab.transform.localPosition, spiderPrefab.transform.forward, spiderAttackRange)) {
                targeting = false;
                spiderSpeed = 0;
                if (!cooldown)
                {
                    cooldown = true;
                    StartCoroutine(CoolDown());
                    anim.SetTrigger("Attack");
                    damageOutput();
                }
            }
            else {
                spiderSpeed = spiderSpeedAdj;
                targeting = true;
            }
        }
    }

    IEnumerator CoolDown ()
    {
        yield return new WaitForSeconds(3);
        cooldown = false;
    }

    public void FollowPlayer ()
    {
      //  transform.LookAt(new Vector3 (player.transform.position.x, transform.position.y, player.transform.position.z));
            transform.Translate(new Vector3(0, 0, spiderSpeed) * Time.deltaTime);
        //transform.Translate(spiderPrefab.transform.forward * spiderSpeed);
    }

    public void damageOutput() {
        print("DamageOutput");
        player.transform.GetComponent<CharacterScript>().TakeDamage(damage, false);
    }

    public void Hit (int i)
    {
        health -= i;
        hpBar.transform.GetComponent<LifeBar>().Damage(maxHealth, i);
        if (health <= 0 && dead == false)
        {
            dead = true;
            anim.SetBool("Death", true);
            StartCoroutine(WaitBeforeDestroy());
        }
    }
    IEnumerator WaitBeforeDestroy()
    {
        yield return new WaitForSeconds(1);
        Instantiate(deathParticle, particlePos.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}