using UnityEngine;
using System.Collections;

public class ObstacleLocationReset : MonoBehaviour {

    public Transform targetLoc;
    void OnTriggerEnter(Collider c)
    {
        if (c.transform.tag == "Player")
        {
            c.transform.position = targetLoc.position;
            //Do damage and stuff
        }
    }
}
