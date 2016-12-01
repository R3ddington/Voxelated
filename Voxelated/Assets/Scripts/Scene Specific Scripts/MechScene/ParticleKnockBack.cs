using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleKnockBack : MonoBehaviour {
    public float force;
    void OnParticleCollision(GameObject g)
    {
        print("triggered particle collision");
        Rigidbody rb = g.GetComponent<Rigidbody>();
        if(rb != null)
        {
            /*
            Vector3 dir = g.transform.position - transform.position;
            dir = dir.normalized;
            */
            if(g.transform.tag == "Player")
            {
                if (g.transform.GetComponent<CharacterScript>().goingLeft)
                {
                    rb.AddForce(force, force / 2, 0);
                }
                else
                {
                    rb.AddForce(-force, force / 2, 0);
                }
            }
        //    rb.AddForce(dir * force);
        }
    }
}
