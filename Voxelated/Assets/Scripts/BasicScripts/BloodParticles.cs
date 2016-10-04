using UnityEngine;
using System.Collections;

public class BloodParticles : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Destroy(gameObject, 3f);
	}
}
