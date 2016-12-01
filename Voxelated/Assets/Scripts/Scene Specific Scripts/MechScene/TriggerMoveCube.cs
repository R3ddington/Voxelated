using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerMoveCube : MonoBehaviour {
    public GameObject target;
    void OnTriggerEnter(Collider c)
    {
        if(c.transform.tag == "Player")
        {
            target.GetComponent<MovingCubes>().SetOn();
            Destroy(gameObject);
        }
    }
}
