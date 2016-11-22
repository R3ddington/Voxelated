using UnityEngine;
using System.Collections;

public class HealthPickUp : MonoBehaviour {
    public int health;
    public int type;

    void OnTriggerEnter(Collider c)
    {
        if(c.transform.tag == "Player")
        {
            switch (type)
            {
                case 0:
                    c.transform.gameObject.GetComponent<CoopPlayerController>().AddHealth(health);
                    break;
                case 1:
                    c.transform.gameObject.GetComponent<CharacterScript>().AddHP(health);
                    break;
            }
            Destroy(gameObject);
        }
    }
}
