using UnityEngine;
using System.Collections;

public class Crusher : MonoBehaviour {
    void OnTriggerEnter(Collider c)
    {
        if (c.transform.tag == "Player")
        {
            c.transform.GetComponent<CharacterScript>().TakeDamage(100000000, true);
        }
    }
}
