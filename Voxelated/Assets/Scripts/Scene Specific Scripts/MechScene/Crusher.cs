using UnityEngine;
using System.Collections;

public class Crusher : MonoBehaviour {
    void OnTriggerEnter(Collider c)
    {
        if (c.transform.tag == "Player")
        {
            c.transform.GetComponent<CharacterScript>().TakeDamage(100000000, true);
        }
        if(c.transform.tag == "Enemy")
        {
            c.transform.GetComponent<EnemyHealth>().Hit(100000000);
        }
    }
}
