using UnityEngine;
using System.Collections;

public class ParticleDestroy : MonoBehaviour {
    public float cooldown;
    // Use this for initialization
    void Start() {
        if (cooldown == 0)
        {
            cooldown = 10;
        }
        Destroy(gameObject, cooldown);
	}
}
