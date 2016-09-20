using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PickUpMaster : MonoBehaviour {

    int healthValue;
   // Transform spawnLoc;
    public List<Transform> healthSpawns = new List<Transform>();
    public GameObject healthPrefab;

	// Use this for initialization
	void Start () {
        Health();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void Health () {
        for(int i = 0; i < healthSpawns.Count; i++) {
            // HealthPickUp health = new HealthPickUp(healthValue, healthSpawns[i]);
            GameObject newHealth = Instantiate(healthPrefab, healthSpawns[i].position, Quaternion.identity) as GameObject;
        }
    }
}
