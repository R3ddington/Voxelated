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
        StartCoroutine(Cooldown());
    }
    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(cooldown);
        if (active)
        {
            Summon();
        }
    }
}
