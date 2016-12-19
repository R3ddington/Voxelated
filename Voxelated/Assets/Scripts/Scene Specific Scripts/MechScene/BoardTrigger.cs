using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardTrigger : MonoBehaviour {
    public GameObject target;
    void OnTriggerEnter(Collider c)
    {
        if (c.transform.tag == "Player")
        {
            if(target.GetComponent<HoverBoard>().isOn == false)
            {
                target.GetComponent<HoverBoard>().SetOn();
            }
            else
            {

            }
            Destroy(gameObject);
            return;
        }
        if(c.transform.tag == "Board")
        {
            if (target.GetComponent<HoverBoard>().isOn == true)
            {
                target.GetComponent<HoverBoard>().SetOff();
                Destroy(gameObject);
            }
        }
    }
}
