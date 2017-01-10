using UnityEngine;
using System.Collections;

public class ShroomJump : MonoBehaviour
{
    public int boost = 2;
    public int cooldown;
    bool onShroom;
    bool cooling;

    public AudioSource aSource;
    public AudioClip[] clip;

    void Start()
    {
        aSource = gameObject.GetComponent<AudioSource>();
        if (aSource != null)
        {
            aSource.clip = clip[0];
        }
    }

    void OnTriggerEnter(Collider c)
    {
        if(c.transform.tag == "Player")
        {
            Rigidbody rb = c.transform.GetComponent<Rigidbody>();
            rb.velocity = rb.velocity * -boost;
            if (boost < 3)
            {
                boost += 1;
            }
            onShroom = true;
            aSource.Play();
        }   
    }
    void OnTriggerExit(Collider c)
    {
        if (c.transform.tag == "Player")
        {
            cooldown = 0;
            if (!cooling)
            {
                cooling = true;
                StartCoroutine(CoolDown());
            }
            onShroom = false;
        }
    }
    IEnumerator CoolDown()
    {
        yield return new WaitForSeconds(1);
        if (!onShroom)
        {
            cooldown++;
            if (cooldown != 5)
            {
                StartCoroutine(CoolDown());
            }
            else
            {
                boost = 2;
                cooling = false;
            }
        }
    }
}