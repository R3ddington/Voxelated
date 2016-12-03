using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketCannon : MonoBehaviour {
    public GameObject rocket;
    public GameObject rocketPos;
    public int cooldown;
    public bool deactived;
    public GameObject target;
    
    public void SetOn()
    {
        if (deactived)
        {
            deactived = false;
            SummonRocket();
        }
    }
    public void SetOff()
    {
        deactived = true;
    }

    public void SummonRocket()
    {
        if (deactived)
        {
            return;
        }
        GameObject newRocket = Instantiate(rocket, rocketPos.transform.position, rocket.transform.rotation) as GameObject;
        newRocket.GetComponent<HostileRocket>().target = target;
        StartCoroutine(WaitForSummon());
    }

    IEnumerator WaitForSummon()
    {
        yield return new WaitForSeconds(cooldown);
        SummonRocket();
    }
}
