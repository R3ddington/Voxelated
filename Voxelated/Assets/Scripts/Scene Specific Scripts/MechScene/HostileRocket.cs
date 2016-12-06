using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HostileRocket : MonoBehaviour {
    public float speed;
    public GameObject target;
    public float damage;
    public GameObject expParticles;
    public bool exploded;
	// Update is called once per frame
	void Update () {
        if (!exploded)
        {
            Move();
        }
	}
    void Move ()
    {
        float moveSpeed = speed * Time.deltaTime;
      //  transform.position = Vector3.MoveTowards(transform.position, target.transform.position, moveSpeed);
    }
    void OnCollisionEnter(Collision c)
    {
        Explode(c.gameObject);
        exploded = true;
    }
    void Explode(GameObject g)
    {
        if(g.transform.tag == "Player")
        {
            g.transform.GetComponent<CharacterScript>().TakeDamage(damage, false);
        }
        Instantiate(expParticles, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
