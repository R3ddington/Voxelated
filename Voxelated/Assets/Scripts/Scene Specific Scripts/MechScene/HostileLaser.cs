using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HostileLaser : MonoBehaviour {
    public float damage;
    void OnParticleCollision(GameObject c)
    {
        if (c.transform.tag == "Player")
        {
            c.transform.GetComponent<CharacterScript>().TakeDamage(damage, false);
        }
    }
}
