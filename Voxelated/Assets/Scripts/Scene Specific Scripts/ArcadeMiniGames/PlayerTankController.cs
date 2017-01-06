using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTankController : MonoBehaviour {
    public float speed;
    public GameObject shot;
    public Transform shotPos;
    public GameObject gameParent;
	void Update () {
        Move();
        CheckInput();
	}

    public void Move ()
    {
        transform.Translate(new Vector3(Input.GetAxis("Horizontal"), 0, 0) * speed * Time.deltaTime);
    }

    public void CheckInput()
    {
        if(Input.GetButtonDown("Fire1") || Input.GetButtonDown("Fire2") || Input.GetButtonDown("Jump"))
        {
            Fire();
        }
    }
    public void Fire()
    {
        GameObject newShot = Instantiate(shot, shotPos.position, shot.transform.rotation) as GameObject;
        newShot.transform.SetParent(gameParent.transform);
    }
}
