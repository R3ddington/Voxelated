using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BazookaRocket : MonoBehaviour {
    bool exploded;
    public int damage;
    public GameObject expParticles;
    public float speed;
    public Vector3 target;
    void Update()
    {
        if (!exploded)
        {
            Move();
        }
    }
    void Move()
    {
        float moveSpeed = speed * Time.deltaTime;
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 78.24f;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        target = mousePos;
        transform.LookAt(target);
        transform.position = Vector3.MoveTowards(transform.position, target, moveSpeed);
        if(transform.position == target)
        {
            Explode(null);
        }
    }
    void OnCollisionEnter(Collision c)
    {
        Explode(c.gameObject);
        exploded = true;
    }
    void Explode(GameObject g)
    {
        if(g != null)
        {
            if (g.transform.tag == "Enemy")
            {
                g.transform.GetComponent<EnemyHealth>().Hit(damage);
            }
        }
        Instantiate(expParticles, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
