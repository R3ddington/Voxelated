using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcadeTankShots : MonoBehaviour {
    public float speed;
    public int damage;
	// Update is called once per frame
	void Update () {
        Move();		
	}

    public void Move()
    {
        transform.Translate(new Vector3(0, 1, 0) * speed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D c)
    {
        if(c.transform.tag == "Enemy")
        {
            c.transform.GetComponent<ArcadeShipHealth>().TakeDamage(damage);
        }
        if(c.transform.tag == "ArcadeBoss")
        {
            c.transform.GetComponent<EnemyHealth>().Hit(damage);
        }
        if(c.transform.tag != "PlayerShot")
        {
            Destroy(gameObject);
        }
    }
}
