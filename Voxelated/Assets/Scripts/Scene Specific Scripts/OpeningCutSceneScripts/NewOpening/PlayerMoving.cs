﻿using UnityEngine;
using System.Collections;

public class PlayerMoving : MonoBehaviour {
    NavMeshAgent nav;
    public Animator anim;
    public Transform target;

    public void Start()
    {
        if (nav == null)
        {
            nav = GetComponent<NavMeshAgent>();
        }
        nav.SetDestination(target.position);
        print("nav mesh target set");
    }

    public void OnTriggerEnter (Collider c)
    {
        if(c.transform.tag == "Target")
        {
            anim.SetBool("Walk", false);
            Destroy(c.gameObject);
        }
    }
}
