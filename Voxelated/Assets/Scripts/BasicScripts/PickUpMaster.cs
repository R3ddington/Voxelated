using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PickUpMaster : MonoBehaviour {
    //Health
    public List<Transform> healthSpawns = new List<Transform>();
    public GameObject healthPrefab;
    public List<GameObject> activeHealth = new List<GameObject>();
    //Shield
    public List<Transform> shieldSpawns = new List<Transform>();
    public GameObject shieldPrefab;
    public List<GameObject> activeShield = new List<GameObject>();
    //Qubits
    public List<Transform> qubitSpawns = new List<Transform>();
    public GameObject qubitPrefab;
    public List<GameObject> activeQubit = new List<GameObject>();


    public void Health ()
    {
        for (int e = 0; e < activeHealth.Count; e++)
        {
            if(activeHealth[e] == null)
            {
                activeHealth.RemoveAt(e);
            }
            else
            {
                GameObject tempH = activeHealth[e].gameObject;
                Destroy(tempH);
                activeHealth.RemoveAt(e);
            }
        }
        for (int i = 0; i < healthSpawns.Count; i++) {
            GameObject newHealth = Instantiate(healthPrefab, healthSpawns[i].position, Quaternion.identity) as GameObject;
            activeHealth.Add(newHealth);
        }
    }

    public void Shield ()
    {
        for (int e = 0; e < activeShield.Count; e++)
        {
            if (activeShield[e] == null)
            {
                activeShield.RemoveAt(e);
            }
            else
            {
                GameObject tempS = activeShield[e].gameObject;
                Destroy(tempS);
                activeShield.RemoveAt(e);
            }
        }
        for (int i = 0; i < shieldSpawns.Count; i++)
        {
            GameObject newShield = Instantiate(shieldPrefab, shieldSpawns[i].position, Quaternion.identity) as GameObject;
            activeShield.Add(newShield);
        }
    }

    public void Qubit()
    {
        for (int e = 0; e < activeQubit.Count; e++)
        {
            if (activeQubit[e] == null)
            {
                activeQubit.RemoveAt(e);
            }
            else
            {
                GameObject tempQ = activeQubit[e].gameObject;
                Destroy(tempQ);
                activeQubit.RemoveAt(e);
            }
        }
        for (int i = 0; i < qubitSpawns.Count; i++)
        {
            GameObject newQubit = Instantiate(qubitPrefab, qubitSpawns[i].position, Quaternion.identity) as GameObject;
            activeQubit.Add(newQubit);
        }
    }
}
