using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorTrigger : MonoBehaviour {
    public GameObject mSpawner;
    public int type;
 //   public GameObject mech;
  //  public Vector3 mechPos;
    void OnTriggerEnter(Collider c)
    {
        if(c.transform.tag == "Player")
        {
            switch (type)
            {
                case 0:
                    mSpawner.GetComponent<AimedMeteorite>().SetOn(c.gameObject);
             //       mech.transform.position = 
                    break;
                case 1:
                    mSpawner.GetComponent<AimedMeteorite>().SetOff();
                    break;
            }
            Destroy(gameObject);
        }
    }
}
