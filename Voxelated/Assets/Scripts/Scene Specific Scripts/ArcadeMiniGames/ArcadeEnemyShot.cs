using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcadeEnemyShot : MonoBehaviour {
    public float speed;
    public int damage;

    void Update()
    {
        Move();
    }

    public void Move()
    {
        transform.Translate(new Vector3(0, 1, 0) * speed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D c)
    {
        if (c.transform.tag == "PlayerTank")
        {
            c.transform.GetComponent<ArcadeShipHealth>().TakeDamage(damage);
            Destroy(gameObject);
        }
        if (c.transform.tag != "Enemy" && c.transform.tag != "EnemyShot")
        {
            Destroy(gameObject);
        }
    }
}
