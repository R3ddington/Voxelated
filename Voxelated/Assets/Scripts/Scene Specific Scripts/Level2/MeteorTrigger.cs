using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorTrigger : MonoBehaviour {
    public GameObject mSpawner;
    public int type;
    void OnTriggerEnter(Collider c)
    {
        if(c.transform.tag == "Player")
        {
            switch (type)
            {
                case 0:
                    mSpawner.GetComponent<AimedMeteorite>().SetOn(c.gameObject);
                    break;
                case 1:
                    mSpawner.GetComponent<AimedMeteorite>().SetOff();
                    break;
            }
        }
    }
}
