using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonTrigger : MonoBehaviour {
    public GameObject cannon;
    public int type;
    void OnTriggerEnter(Collider c)
    {
        if(c.transform.tag == "Player")
        {
            switch (type)
            {
                case 0:
                    cannon.GetComponent<RocketCannon>().SetOn();
                    break;
                case 1:
                    cannon.GetComponent<RocketCannon>().SetOff();
                    break;
            }
        }
    }
}
