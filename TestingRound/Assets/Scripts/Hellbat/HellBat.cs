using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HellBat : MonoBehaviour {

    public float speedBat;

	// Update is called once per frame
	void Update () {
        HBMovement();
	}

    public void HBMovement() {
        transform.Translate(transform.forward * speedBat * Time.deltaTime);
    }
}
