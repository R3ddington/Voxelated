using UnityEngine;
using System.Collections;

public class CoopPortals : MonoBehaviour {
    public Transform tpLoc;

    void OnTriggerEnter(Collider c)
    {
        if(c.transform.tag == "Player")
        {
            c.transform.position = tpLoc.position;
        }
    }
}
