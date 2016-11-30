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
            Vector3 dir = g.transform.position - transform.position;
            dir = dir.normalized;
            rb.AddForce(dir * force);
        }
    }
}
