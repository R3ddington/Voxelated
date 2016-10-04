using UnityEngine;
using System.Collections;

public class TurretScript : MonoBehaviour {
    public int health;
    public int[] getDamage; //0 = Strypu attack
    public bool isNexus;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter(Collider c)
    {
        string tag = c.transform.tag;
        switch (tag)
        {
            case "StrypuHand":
                Damage(0);
                break;
        }
    }

    void Damage (int i)
    {
        health -= getDamage[i];
        if(health <= 0)
        {
            //Do explosion here
            Destroy(gameObject, 2f);
            if (isNexus)
            {
                //GameOver
            }
        }
    }
}
