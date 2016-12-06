using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeZombie : MonoBehaviour {

    public Animator treeZombieAnim;
    public float playerInRange;
    public float playerHitable;
    public RaycastHit playerHit;

	// Update is called once per frame
	void Update () {
        DetectManager();
	}

    public void DetectManager() {
        if(Physics.Raycast(transform.position, transform.forward, out playerHit, playerInRange)) {
            if (playerHit.transform.tag == "Player") {
                treeZombieAnim.SetBool("Walking", true);
                if (Physics.Raycast(transform.position, transform.forward, playerHitable))
                    treeZombieAnim.SetTrigger("Melee");
            }
        }
        /*if(TreeZombieHealth <= 0)
            treeZombieAnim.SetBool("Death", true); 

           misschien nog de ground attack ergens ( treeZombieAnim.SetBool("GroundAttack", true); ) maar kan zijn dat we die dus niet doen */
        
            
    }
}
