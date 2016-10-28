using UnityEngine;
using System.Collections;
using System;

public class CharacterScript : MonoBehaviour {
    public int health;
    public Animator anim;
    public bool freeze;
    public bool hitFreeze;
    public int[] speed; //0 = using speed, 1 = normal speed, 2 = sprint speed, 3 = crouch speed
    public int cMode;  //0 = Katana mode
    public BoxCollider boxCollider;
    public int[] hitboxHeight; //0 = normal size, 1 = crouch size
    public int[] hitboxCenter; //0 = normal center, 1 = crouch center
    public bool goingLeft;
    public float turnSpeed;
    public GameObject model;
    int turnDir;
    public bool turning;

    // Use this for initialization
    void Start () {
        boxCollider = GetComponent<BoxCollider>() as BoxCollider;
    }
	
	// Update is called once per frame
	void Update () {
        OnButtonDown();
        if (turning)
        {
            Turn(turnDir);
        }
	}

    public void SetUp()
    {

    }
    
    //Button Input
    void OnButtonDown() {
        if (!freeze)
        {
            if (!hitFreeze)
            {
                if (Input.GetButtonDown("Fire1"))
                {
                    switch (cMode)
                    {
                        case 0:
                            anim.SetTrigger("Slash");
                            break;
                    }
                }
                if (Input.GetButtonDown("Fire2"))
                {
                    switch (cMode)
                    {
                        case 0:
                            anim.SetTrigger("Spin");
                            break;
                    }
                }
            }
            if (Input.GetButtonDown("S"))
            {
                anim.SetBool("Crouch", true);
                Crouch();
            }
            if (Input.GetButtonUp("S"))
            {
                anim.SetBool("Crouch", false);
                Crouch();
            }
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
            if (Input.GetButtonDown("Jump"))
            {
                if (!freeze)
                {
                    Jump();
                }
            }
        }
        else
        {
            MoveOff();
        }
    }

    //Character Walking
    void Moving()
    {
        if (!freeze)
        {
            transform.Translate(new Vector3(0, 0, Input.GetAxis("Horizontal")) * speed[0] * Time.deltaTime);
            if (Input.GetAxis("Horizontal") < 0)
            {
                if (!goingLeft)
                {
                    goingLeft = true;
                    turnDir = -90;
                    turning = true;
                }
            }
            else
            {
                if (goingLeft)
                {
                    goingLeft = false;
                    turnDir = 90;
                    turning = true;
                }
            }
            if (anim.GetBool("Walk") == false)
            {
                anim.SetBool("Walk", true);
            }
        }
    }

    void Turn (int i)
    {
        model.transform.rotation = Quaternion.Lerp(model.transform.rotation, Quaternion.Euler(0, i, 0),  Time.deltaTime * turnSpeed);
        if (goingLeft)
        {
            if(model.transform.rotation.y == 180)
            {
                turning = false;
            }
        }
        else
        {
            if(model.transform.rotation.y == 0)
            {
                turning = false; //ß
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

    void Crouch ()
    {
        if (anim.GetBool("Crouch"))
        {
            boxCollider.size = new Vector3(boxCollider.size.x, hitboxHeight[1], boxCollider.size.z);
            boxCollider.center = new Vector3(boxCollider.center.x, hitboxCenter[1], boxCollider.center.z);
        }
        else
        {
            boxCollider.size = new Vector3(boxCollider.size.x, hitboxHeight[0], boxCollider.size.z);
            boxCollider.center = new Vector3(boxCollider.center.x, hitboxCenter[0], boxCollider.center.z);
        }

    }
    public void Freeze ()
    {
        if (!freeze)
        {
            freeze = true;
        }
        else
        {
            freeze = false;
        }
    }
    public void HitFreezeOn()
    {
        hitFreeze = true;
    }
    public void HitFreezeOff()
    {
        hitFreeze = false;
    }
}