using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcadeEnemy : MonoBehaviour {

    public int shotOffset;
    public float cooldown;
    public bool cooling;
    public GameObject shot;
    public GameObject gameParent;

    void Start ()
    {
        cooling = true;
        StartCoroutine(Cooler());
    }

    void Update () {
        CheckFirePerm();
	}

    public void CheckFirePerm ()
    {
        if (!cooling)
        {
            cooling = true;
            StartCoroutine(Cooler());
            Fire();
        }
    }

    public void Fire()
    {
        Vector3 shotPos = transform.position;
        shotPos.y -= shotOffset;
        GameObject newShot = Instantiate(shot, shotPos, shot.transform.rotation) as GameObject;
        newShot.transform.SetParent(gameParent.transform);
    }

    IEnumerator Cooler()
    {
        cooldown = Random.Range(300, 601);
        cooldown = cooldown / 100;
        yield return new WaitForSeconds(cooldown);
        cooling = false;
    }
}
