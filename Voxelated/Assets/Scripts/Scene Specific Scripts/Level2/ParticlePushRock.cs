using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlePushRock : MonoBehaviour {
    public float force;
    void OnParticleCollision(GameObject g)
    {
        if(g.transform.tag == "ParticleMove")
        {
            Rigidbody rb = g.GetComponent<Rigidbody>();
            rb.AddForce(0, force, 0);
        }
    }
}
