using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBullet : MonoBehaviour {
    public float speed;
    public float damage;

    void Update () {
        transform.Translate(Vector3.forward * speed);
	}
    void OnCollisionEnter(Collision c)
    {
        if(c.transform.tag == "Player")
        {
            c.transform.GetComponent<CharacterScript>().TakeDamage(damage, false);
        }
        Destroy(gameObject);
    }
}
