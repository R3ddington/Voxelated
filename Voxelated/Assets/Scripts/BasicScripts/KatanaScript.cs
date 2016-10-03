﻿using UnityEngine;
using System.Collections;

public class KatanaScript : MonoBehaviour {
    public int baseDamage;
    public int dealDamage;
    public int maxDamage;
    public int combo;
    public bool active;
    public GameObject blood;
    public GameObject owner;
    /*
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    */
    public void SetOn ()
    {
        active = true;
    }

    public void SetOff()
    {
        active = false;
    }

    void OnTriggerEnter(Collider c)
    {
        if (!active)
        {
            return;
        }
        float tempD = baseDamage + (0.5f * combo / 4f);
        dealDamage = (int)tempD;
        if (dealDamage > maxDamage)
        {
            dealDamage = maxDamage;
        }
        string tag = c.transform.tag;
        switch (tag)
        {
            case "Strypu":
                c.GetComponent<Strypu>().Damage(dealDamage);
                Bleed(c.transform.gameObject);
                combo++;
                break;
            case "Player":
                Bleed(c.transform.gameObject);
                break;
            case "Guardian":
                c.GetComponent<Guardian>().Damage(dealDamage, owner);
                Bleed(c.transform.gameObject);
                combo++;
                break;
        }
    }

    void Bleed (GameObject c)
    {
        GameObject newBlood = Instantiate(blood, c.transform.position, Quaternion.identity) as GameObject;
    }
}
