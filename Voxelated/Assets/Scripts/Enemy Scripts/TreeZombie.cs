using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeZombie : MonoBehaviour {

    public Animator treeZombieAnim;
    public float playerInRange;
    public float playerHitable;
    public RaycastHit playerHit;
    public GameObject playerModel;
    public Vector3 rayInsDis;
    public Vector3 playerGrAtRange;
    public GameObject rayOrigin;

	// Update is called once per frame
	void Update () {
        DetectManager();
	}

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
                
}
