using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementalAttack : MonoBehaviour {
    public int damage;
	void OnCollisionEnter (Collision c)
    {
        if(c.transform.tag == "Player")
        {
            c.transform.GetComponent<CharacterScript>().TakeDamage(damage, false);
        }
    }
}
