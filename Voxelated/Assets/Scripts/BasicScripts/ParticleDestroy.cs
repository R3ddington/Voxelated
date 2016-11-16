using UnityEngine;
using System.Collections;

public class ParticleDestroy : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Destroy(gameObject, 10f);
	}
}
