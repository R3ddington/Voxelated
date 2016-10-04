﻿using UnityEngine;
using System.Collections;

public class CharacterScript : MonoBehaviour {
    public int health;
    public Animator anim;
    public bool freeze;
    public int[] speed; //0 = using speed, 1 = normal speed, 2 = sprint speed

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        OnButtonDown();
	}

    public void SetUp()
    {

    }
    
    //Button Input
    void OnButtonDown() {
        if (Input.GetAxis("Horizontal") != 0)
        {
            Moving();
            if (Input.GetButtonDown("LShift"))
            {
                //do sprint speed
                speed[0] = speed[2];
                anim.SetBool("Run", true);
            }
            if (Input.GetButtonUp("LShift"))
            {
                speed[0] = speed[1];
                anim.SetBool("Run", false);
            }
        }
        else
        {
            MoveOff();
        }
        if (Input.GetButtonDown("Jump")) {
            if (!freeze) {
                Jump();
            }
        }
    }

    //Character Walking
    void Moving()
    {
        if (!freeze)
        {
            transform.Translate(new Vector3(0, 0, Input.GetAxis("Horizontal")) * speed[0] * Time.deltaTime);
            if (anim.GetBool("Walk") == false)
            {
                anim.SetBool("Walk", true);
            }
        }
    }

    void MoveOff()
    {
        anim.SetBool("Walk", false);
    }

    void Jump () {
        //Do jumping
    }
}
