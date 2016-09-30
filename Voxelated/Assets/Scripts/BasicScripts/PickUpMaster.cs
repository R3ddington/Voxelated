using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PickUpMaster : MonoBehaviour {

    int healthValue;
   // Transform spawnLoc;
    public List<Transform> healthSpawns = new List<Transform>();
    public GameObject healthPrefab;
    public List<Transform> shieldSpawns = new List<Transform>();
    public GameObject shieldPrefab;

    public void Health () {
        for(int i = 0; i < healthSpawns.Count; i++) {
            // HealthPickUp health = new HealthPickUp(healthValue, healthSpawns[i]);
            GameObject newHealth = Instantiate(healthPrefab, healthSpawns[i].position, Quaternion.identity) as GameObject;
        }
    }

    public void Shield ()
    {
        for(int i = 0; i < shieldSpawns.Count; i++)
        {
            GameObject newShield = Instantiate(shieldPrefab, shieldSpawns[i].position, Quaternion.identity) as GameObject;
        }
    }
}
