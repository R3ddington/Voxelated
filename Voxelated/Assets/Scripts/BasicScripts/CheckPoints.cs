using UnityEngine;
using System.Collections;

public class CheckPoints : MonoBehaviour {
    public GameObject checkpointMaster;
    void OnTriggerEnter(Collider c)
    {
        if(c.transform.tag == "Player")
        {
            int i = c.transform.GetComponent<CharacterScript>().qubits;
            print("Sending qubits" + i.ToString());
            checkpointMaster.GetComponent<CheckPointManager>().SetPoint(gameObject, i);
        }
    }
}
