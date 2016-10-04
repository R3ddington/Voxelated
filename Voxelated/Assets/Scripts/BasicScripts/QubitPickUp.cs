using UnityEngine;
using System.Collections;

public class QubitPickUp : MonoBehaviour {
    public int value;
    public GameObject waveSystem;

    void Start ()
    {
        waveSystem = GameObject.FindGameObjectWithTag("MainCamera");
    }

    void OnTriggerEnter(Collider c)
    {
        if (c.transform.tag == "Player")
        {
            waveSystem.GetComponent<CoopWaveSystem>().AddQubits(value);
            Destroy(gameObject);
        }
    }
}
