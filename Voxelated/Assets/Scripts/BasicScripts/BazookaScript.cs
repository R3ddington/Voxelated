using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BazookaScript : MonoBehaviour {
    public int countdown;
    public bool cooling;
    public GameObject barrelEnd;
    public GameObject rocket;
    public void Fire()
    {
        if (!cooling)
        {
            cooling = true;
          //  Vector3 mousePos = Input.mousePosition;
          //  mousePos.z = 78.24f;
          //  mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            GameObject newRocket = Instantiate(rocket, barrelEnd.transform.position, rocket.transform.rotation) as GameObject;
            //newRocket.GetComponent<BazookaRocket>().target = mousePos;
            StartCoroutine(Cooldown());
        }
    }

    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(countdown);
        cooling = false;
    }
}
