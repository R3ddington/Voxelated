using UnityEngine;
using System.Collections;

public class TurretScript : MonoBehaviour {
    public int health;
    public int[] getDamage; //0 = Strypu attack, 1 = Guardian attack
    public bool isNexus;
    public GameObject gameOver;
    bool dead;

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
            case "GuardianHand":
                Damage(1);
                break;
        }
    }

    void Damage (int i)
    {
        health -= getDamage[i];
        if (!dead)
        {
            if (health <= 0)
            {
                //Do explosion here
                dead = true;
                Destroy(gameObject, 2f);
                if (isNexus)
                {
                    //GameOver
                    StartCoroutine(NexusWait());
                }
            }
        }
    }
    IEnumerator NexusWait()
    {
        yield return new WaitForSeconds(1);
        gameOver.SetActive(true);
    }
}