using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimedMeteorite : MonoBehaviour {

    public bool active;
    public GameObject meteor;
    public int min;
    public int max;
    public GameObject player;
    public int cooldown;
    public bool cooling;
    public int spawnAmount;
    public int spawnLeft;
    public GameObject warn;

    public void SetOn(GameObject g)
    {
        if (!active)
        {
            active = true;
            player = g;
            Summon();
        }
    }

    public void SetOff()
    {
        active = false;
    }

    public void Summon()
    {
        float offset = Random.Range(min, max);
        Vector3 targetLoc = new Vector3(player.transform.position.x + offset, meteor.transform.position.y, player.transform.position.z);
        Instantiate(meteor, targetLoc, meteor.transform.rotation);
        RaycastHit hit;
        if(Physics.Raycast(targetLoc, Vector3.down, out hit, 1000))
        {
            // print("Found" + hit.transform.name);
            Vector3 warnPos = new Vector3(hit.point.x, hit.point.y + 10f, hit.point.z);
            Instantiate(warn, warnPos, warn.transform.rotation);
        }
        spawnLeft--;
        if(spawnLeft <= 0)
        {
            StartCoroutine(Cooldown());
        }
        else
        {
            Summon();
        }
    }
    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(cooldown);
        if (active)
        {
            spawnLeft = spawnAmount;
            Summon();
        }
    }
}
