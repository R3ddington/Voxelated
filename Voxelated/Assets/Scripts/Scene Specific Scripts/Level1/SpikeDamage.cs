using UnityEngine;
using System.Collections;

public class SpikeDamage : MonoBehaviour {

    public float damage = 10;

    void OnCollisionEnter(Collision c)
    {
        if(c.transform.tag == "Player")
        {
            c.transform.GetComponent<CharacterScript>().TakeDamage(damage, false);
            Rigidbody rb = c.transform.GetComponent<Rigidbody>();
            rb.AddExplosionForce(7500f, transform.position, 200f);
            Destroy(gameObject);
        }
    }
}