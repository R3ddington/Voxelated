using UnityEngine;
using System.Collections;

public class HealthPickUp : MonoBehaviour {
    public int health;
    
    void OnTriggerEnter(Collider c)
    {
        if(c.transform.tag == "Player")
        {
            c.transform.gameObject.GetComponent<CoopPlayerController>().AddHealth(health);
            Destroy(gameObject);
        }
    }
}
