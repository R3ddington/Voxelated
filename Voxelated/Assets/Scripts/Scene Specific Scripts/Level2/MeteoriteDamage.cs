using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoriteDamage : MonoBehaviour {
    public int damage;
    public AudioClip[] clip;
    public GameObject meteorSound;
    public bool canPlay;
    /*
    void Start()
    {
        aSource = gameObject.GetComponent<AudioSource>();
        if (aSource != null)
        {
            aSource.clip = clip[0];
        }
    }
    */
    void OnParticleCollision(GameObject g)
    {
        Vector3 ePos = g.transform.position;
        ePos.y += 30;
        //  AudioSource.PlayClipAtPoint(clip[0], ePos, 1.0F);
        if (canPlay)
        {
            Instantiate(meteorSound, ePos, transform.rotation);
        }
        if (g.transform.tag == "Enemy")
        {
            g.GetComponent<EnemyHealth>().Hit(damage);
        }
        if(g.transform.tag == "Player")
        {
            g.GetComponent<CharacterScript>().TakeDamage(damage, false);
        }
        
    }
}
