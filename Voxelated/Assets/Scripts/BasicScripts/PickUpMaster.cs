using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PickUpMaster : MonoBehaviour {
    //Health
    public List<Transform> healthSpawns = new List<Transform>();
    public GameObject healthPrefab;
    public List<Transform> activeHealth = new List<Transform>();
    //Shield
    public List<Transform> shieldSpawns = new List<Transform>();
    public GameObject shieldPrefab;
    public List<Transform> activeShield = new List<Transform>();
    //Qubits
    public List<Transform> qubitSpawns = new List<Transform>();
    public GameObject qubitPrefab;
    public List<Transform> activeQubit = new List<Transform>();

    public void Health ()
    {
        ClearList(activeHealth);
        for (int i = 0; i < healthSpawns.Count; i++) {
            GameObject newHealth = Instantiate(healthPrefab, healthSpawns[i].position, Quaternion.identity) as GameObject;
            activeHealth.Add(newHealth.transform);
        }
    }

    public void Shield ()
    {
        ClearList(activeShield);
        for (int i = 0; i < shieldSpawns.Count; i++)
        {
            GameObject newShield = Instantiate(shieldPrefab, shieldSpawns[i].position, Quaternion.identity) as GameObject;
            activeShield.Add(newShield.transform);
        }
    }

    public void Qubit()
    {
        ClearList(activeQubit);
        for (int i = 0; i < qubitSpawns.Count; i++)
        {
            GameObject newQubit = Instantiate(qubitPrefab, qubitSpawns[i].position, Quaternion.identity) as GameObject;
            activeQubit.Add(newQubit.transform);
        }
    }

    public void ClearList (List<Transform> toClear)
    {
        for (int e = 0; e < toClear.Count; e++)
        {
            if (toClear[e] != null)
            {
                Destroy(toClear[e].gameObject);
            }
        }
        toClear.Clear();
    }
}