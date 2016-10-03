using UnityEngine;
using System.Collections;

public class Guardian : MonoBehaviour {

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
    public int health;
    bool dead;
    public GameObject databank;
    public int lane;
    bool prepared;
    bool done;
    public GameObject targetObject;
    // Use this for initialization
    NavMeshAgent nav;
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!done)
        {
            if (prepared)
            {
                if (!dead)
                {
                    if (triggered)
                    {
                        TargetPlayer();
                    }
                    distance = Vector3.Distance(target, transform.position);
                    if (distance > 7)
                    {
                        if (anim.GetBool("Walk") == false)
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
            }
        }

    }

    public void SetLane(int i)
    {
        lane = i;
        if (databank == null)
        {
            databank = GameObject.FindGameObjectWithTag("Databank");
        }
        databank.GetComponent<CoopDataHolder>().GetRequest(lane, gameObject);
    }

    public void CustomStart()
    {
        Targeting();
    }

    public void GainInfo(GameObject turret1, GameObject turret2, GameObject nexus)
    {
        turrets[0] = turret1;
        turrets[1] = turret2;
        turrets[2] = nexus;
        CustomStart();
        prepared = true;
    }

    void Targeting()
    {
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
            else
            {
                TargetTurret(2);
            }
            if (turrets[2] == null)
            {
                done = true;
            }
        }
    }

    void TargetTurret(int i)
    {
        if (!(turrets[i] == null))
        {
            target = turrets[i].transform.position;
            if (nav == null)
            {
                nav = GetComponent<NavMeshAgent>();
            }
            nav.SetDestination(target);
        }
    }

    void TargetPlayer ()
    {
        target = targetObject.transform.position;
        nav.SetDestination(target);
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
        if (!triggered)
        {
            Targeting();
        }
    }

    public void Damage(int i, GameObject g)
    {
        health -= i;
        if(g.transform.tag == "Player")
        {
            targetObject = g;
            triggered = true;
        }
        else
        {
            if(g.transform.tag == "Turret")
            {
                targetObject = g;
                triggered = false;
            }
        }
        if (health <= 0)
        {
            if (!dead)
            {
                dead = true;
                anim.SetTrigger("Dead");
                //Give player Qubits
                databank.GetComponent<CoopDataHolder>().SendQubits(5);
                Destroy(gameObject, 3f);
            }
        }
    }
}
