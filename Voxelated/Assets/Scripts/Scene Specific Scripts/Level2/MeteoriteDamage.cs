using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoriteDamage : MonoBehaviour {
    public int damage;
    void OnParticleCollision(GameObject g)
    {
        if(g.transform.tag == "Enemy")
        {
            g.GetComponent<EnemyHealth>().Hit(damage);
        }
        if(g.transform.tag == "Player")
        {
            g.GetComponent<CharacterScript>().TakeDamage(damage, false);
        }
    }
}
