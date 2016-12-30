using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelEndTargeting : MonoBehaviour {
    public GameObject player;

	// Update is called once per frame
	void Update () {
        if(player != null)
        {
            transform.LookAt(new Vector3(player.transform.position.x, player.transform.position.y + 20, player.transform.position.z));
        }
	}
}
