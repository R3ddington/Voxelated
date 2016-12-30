using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaLizard : MonoBehaviour {
    public Animator anim;
    public GameObject player;
    public bool actived;
    public float attackRange;
    public bool cooling;
    public float coolTimer;
    public float standTimer;
    public GameObject bullet;
    public GameObject barrelEnd;

    public void GetPlayer(GameObject p)
    {
        player = p;
        actived = true;
        barrelEnd.GetComponent<BarrelEndTargeting>().player = p;
    }

	// Update is called once per frame
	void Update () {
        if (actived)
        {
            Prepare();
        }
	}

    public void Prepare()
    {
        float dist = Vector3.Distance(player.transform.position, transform.position);
        if (dist < attackRange)
        {
            if (!cooling)
            {
                cooling = true;
                Attack();
            }
        }
    }
    public void Attack()
    {
        anim.SetBool("Stand", true);
        StartCoroutine(WaitBeforeSittingDown());
        StartCoroutine(Shooting());
    }

    public void Shot()
    {
        Instantiate(bullet, barrelEnd.transform.position, barrelEnd.transform.rotation);
    }

    IEnumerator Shooting ()
    {
        yield return new WaitForSeconds(1);
        Shot();
        yield return new WaitForSeconds(0.5f);
        Shot();
        yield return new WaitForSeconds(0.5f);
        Shot();
    }

    IEnumerator WaitBeforeSittingDown()
    {
        yield return new WaitForSeconds(standTimer);
        anim.SetBool("Stand", false);
        yield return new WaitForSeconds(coolTimer);
        cooling = false;
    }
}
