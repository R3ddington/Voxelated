﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonAnimplusChange : MonoBehaviour {

    public GameObject rayOrigin;
    public RaycastHit playerHit;
    public float rayLengthStanDet;
    public float rayLengthMeleeDet;
    public Animator skeletonAnim;
    public float skeletonHP;
    public GameObject skeletonHalf;
    public GameObject transformParticle;
    public GameObject particlePos;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        SkeletonMoAtt();
        SkeletonHalfation();
	}

    public void SkeletonMoAtt() {
        if (Physics.Raycast(rayOrigin.transform.position, rayOrigin.transform.forward, out playerHit, rayLengthStanDet)) {
            skeletonAnim.SetBool("Running", true);
            if (Physics.Raycast(rayOrigin.transform.position, rayOrigin.transform.forward, out playerHit, rayLengthMeleeDet)) {
                skeletonAnim.SetTrigger("Attack");
                skeletonAnim.SetBool("Running", false);
                
            }
        }
        else {
            skeletonAnim.SetBool("Running", false);
        }
    }


    public void SkeletonHalfation() {
        if(/*skeletonHP <= 0*/Input.GetButtonDown("Jump")) {
            //skeletonAnim.SetBool("Death", true);
            //Instantiate(transformParticle, particlePos.transform.position, Quaternion.identity);
            StartCoroutine(destroyWait());
             

        }
    }

    IEnumerator destroyWait() {
        //Instantiate(transformParticle, particlePos.transform.position, Quaternion.identity);
        skeletonAnim.SetBool("Death", true);
        yield return new WaitForSeconds(2);
        skeletonAnim.SetBool("Death", true);
        Instantiate(transformParticle, particlePos.transform.position, Quaternion.identity);
        Instantiate(skeletonHalf, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

}
