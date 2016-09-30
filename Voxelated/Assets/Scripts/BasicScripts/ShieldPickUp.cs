using UnityEngine;
using System.Collections;

public class ShieldPickUp : MonoBehaviour {
    public int shield;

    void OnTriggerEnter(Collider c)
    {
        if (c.transform.tag == "Player")
        {
            c.transform.gameObject.GetComponent<CoopPlayerController>().AddShield(shield);
            Destroy(gameObject);
        }
    }
}
