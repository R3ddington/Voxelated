using UnityEngine;
using System.Collections;

public class ObstacleLocationReset : MonoBehaviour {

    public Transform targetLoc;
    public float damage;
    void OnTriggerEnter(Collider c)
    {
        if (c.transform.tag == "Player")
        {
            c.transform.position = targetLoc.position;
            c.GetComponent<CharacterScript>().TakeDamage(damage, true);
        }
    }
}
