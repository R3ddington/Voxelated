using UnityEngine;
using System.Collections;

public class QubitPickUp : MonoBehaviour {
    public int value;
    public GameObject waveSystem;
    public int type;

    void Start ()
    {
        waveSystem = GameObject.FindGameObjectWithTag("MainCamera");
    }

    void OnTriggerEnter(Collider c)
    {
        if (c.transform.tag == "Player")
        {
            switch (type)
            {
                case 0:
                    waveSystem.GetComponent<CoopWaveSystem>().AddQubits(value);
                    break;
                case 1:
                    c.transform.gameObject.GetComponent<CharacterScript>().AddQubits(value);
                    break;
            }
            
            Destroy(gameObject);
        }
    }
}