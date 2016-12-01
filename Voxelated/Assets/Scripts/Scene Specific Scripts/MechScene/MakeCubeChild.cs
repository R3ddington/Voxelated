using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeCubeChild : MonoBehaviour {

    void OnCollisionEnter(Collision c)
    {
        if (c.transform.tag == "Player")
        {
            c.transform.parent = transform;
        }
    }
    void OnCollisionExit(Collision c)
    {
        if (c.transform.tag == "Player")
        {
            c.transform.parent = null;
        }
    }
}
