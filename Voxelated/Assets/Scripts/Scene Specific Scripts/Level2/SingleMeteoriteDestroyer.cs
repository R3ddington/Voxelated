using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleMeteoriteDestroyer : MonoBehaviour {

    void OnParticleCollision(GameObject g)
    {
        Destroy(gameObject,3f);
    }
}
