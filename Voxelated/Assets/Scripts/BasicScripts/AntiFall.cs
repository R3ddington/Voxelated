using UnityEngine;
using System.Collections;

public class AntiFall : MonoBehaviour {
    public float damage;
    public GameObject checkpointMaster;
    void OnTriggerEnter(Collider c)
    {
        if(c.transform.tag == "Player")
        {
            c.transform.GetComponent<CharacterScript>().TakeDamage(damage, true);
            checkpointMaster.GetComponent<CheckPointManager>().GoToPoint(c.transform.gameObject);
        }
    }
}
