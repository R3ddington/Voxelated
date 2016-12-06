using UnityEngine;
using System.Collections;
using System;

public class CharacterScript : MonoBehaviour {
    public int health;
    public float shield;
    public Animator anim;
    public bool freeze;
    public bool hitFreeze;
    public int[] speed; //0 = using speed, 1 = normal speed, 2 = sprint speed, 3 = crouch speed
    public int cMode;  //0 = Katana mode, 1 = Gun mode
    public BoxCollider boxCollider;
    public int[] hitboxHeight; //0 = normal size, 1 = crouch size
    public int[] hitboxCenter; //0 = normal center, 1 = crouch center
    public bool goingLeft;
    public float turnSpeed;
    public GameObject model;
    int turnDir;
    public bool turning;
    public GameObject[] backItems; //0 = katana, 1 = gun, 2 = skull sword
    public GameObject[] handItems; //0 = katana, 1 = gun, 2 = skull sword
    public int selectedSword; //0 = katana
    public int selectedGun; //1 = basegun
    public bool[] unlockedItems; //0 = katana, 1 = gun, 2 = skull sword
    bool switching;
    public bool aiming;
    public GameObject gunScript;
    public bool specialLock;
    Rigidbody rb;
    public int jumpSpeed;
    public bool jumping;
    bool onLog;
    public Vector3 vel;
    public GameObject hud;
    public int qubits;
    public GameObject audioHandler;
    public bool reloaded;
  //  public Vector3 checkpointPos;


    // Use this for initialization
    void Start() {
        DontDestroyOnLoad(this);
        SetUp();
    }

    // Update is called once per frame
    void Update() {
        OnButtonDown();
        if (turning)
        {
            Turn(turnDir);
        }
        if (jumping)
        {
            Fall();
        }
        vel = rb.velocity; //To check velocity in editor, remove for final build
    }

    public void SetToDontDestroy()
    {
        DontDestroyOnLoad(this);
    }

    public void SetUp()
    {
        if (audioHandler == null)
        {
            audioHandler = GameObject.FindGameObjectWithTag("AudioMaster");
        }
        boxCollider = GetComponent<BoxCollider>() as BoxCollider;
        rb = GetComponent<Rigidbody>();
        hud = GameObject.FindGameObjectWithTag("Hud");
        if (hud == null)
        {
            print("WARNING HUD NOT FOUND, CHARACTERSCRIPT LINE 71, RECHECKING IN 1 SECOND");
            StartCoroutine(SecondHudCheck());
        }
        else
        {
            AddQubits(0);
        }
        freeze = false;
    }

    IEnumerator SecondHudCheck()
    {
        yield return new WaitForSeconds(1);
        hud = GameObject.FindGameObjectWithTag("Hud");
        if (hud == null)
        {
            print("SECOND HUD CHECK DIDNT FIND A HUD!");
        }
        else
        {
            AddQubits(0);
        }
    }

    //Button Input
    void OnButtonDown() {
        if (!freeze)
        {
            if (!hitFreeze)
            {
                if (Input.GetButtonDown("I"))
                {
                    transform.position = new Vector3(3553.299f, -193.1f, -2954.95f);
                }

                if (Input.GetButtonDown("1"))
                {
                    if (!switching && anim.GetBool("Walk") == false && anim.GetBool("Crouch") == false)
                    {
                        switch (cMode)
                        {
                            case 0:
                                print("Allready using katana");
                                break;
                            case 1:
                                cMode = 0;
                                TakeItem(3);
                                switching = true;
                                freeze = true;
                                StartCoroutine(WaitTillSwitch(0, 1));
                                break;
                        }
                    }
                }
                if (Input.GetButtonDown("2"))
                {
                    if (!switching && anim.GetBool("Walk") == false && anim.GetBool("Crouch") == false)
                    {
                        switch (cMode)
                        {
                            case 0:
                                cMode = 1;
                                TakeItem(1);
                                switching = true;
                                freeze = true;
                                StartCoroutine(WaitTillSwitch(2, 1));
                                break;
                            case 1:
                                print("Allready using pistol");
                                break;
                        }
                    }
                }
                if (Input.GetButtonUp("Fire2"))
                {
                    aiming = false;
                    anim.SetBool("Aiming", false);
                    gunScript.GetComponent<LaserScript>().Lock(1);
                }

                if (Input.GetButtonDown("Fire1"))
                {
                    if (!switching && !jumping)
                    {
                        switch (cMode)
                        {
                            case 0:
                                anim.SetTrigger("Slash");
                                if (audioHandler != null)
                                {
                                    audioHandler.GetComponent<AudioMaster>().PlayDelay(2 , 0.5f);
                                }
                                break;
                        }
                    }
                }
                if (Input.GetButtonDown("Fire2"))
                {
                    if (!switching && !jumping)
                    {
                        switch (cMode)
                        {
                            case 0:
                                if (audioHandler != null)
                                {
                                    audioHandler.GetComponent<AudioMaster>().PlayDelay(2, 0.5f);
                                }
                                anim.SetTrigger("Spin");
                                break;
                            case 1:
                                aiming = true;
                                anim.SetBool("Aiming", true);
                                gunScript.GetComponent<LaserScript>().Lock(0);
                                break;
                        }
                    }
                }
            }
            if (Input.GetButtonDown("S"))
            {
                if (rb.velocity == new Vector3(0, 0, 0))
                {
                    anim.SetBool("Crouch", true);
                    Crouch();
                }
            }
            if (Input.GetButtonUp("S"))
            {
                //Fix velocity bugs
                if (rb.velocity == new Vector3(0, -0.0001525879f, 0))
                {
                    rb.velocity = new Vector3(0, 0, 0);
                }
                if (rb.velocity == new Vector3(0, 0, 0))
                {
                    anim.SetBool("Crouch", false);
                    Crouch();
                }
            }
            if (Input.GetAxis("Horizontal") != 0)
            {
                Moving();
                if (Input.GetButtonDown("LShift"))
                {
                    if (!aiming)
                    {
                        //do sprint speed
                        speed[0] = speed[2];
                        anim.SetBool("Run", true);
                    }
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
                    if (onLog == true)
                    {
                        Jump();
                    }
                    //Check if velocity isnt bugged, if it is this should fix it
                    if (rb.velocity == new Vector3(0, -0.0003051758f, 0) || rb.velocity == new Vector3(0, -0.0001525879f, 0) || rb.velocity == new Vector3(0, -3.814697e-05f, 0) || rb.velocity == new Vector3(0, -0.0001144409f, 0))
                    {
                        rb.velocity = new Vector3(0, 0, 0);
                    }
                    if (rb.velocity == new Vector3(0, 0, 0))
                    {
                   //     if (!anim.GetBool("Crouch"))
                   //     {
                            Jump();
                  //      }
                    }
                }
            }
        }
        else
        {
            MoveOff();
        }
    }

    void Jump()
    {
        if(audioHandler != null)
        {
            audioHandler.GetComponent<AudioMaster>().PlaySound(1);
        }
        rb.velocity = new Vector3(0, jumpSpeed, 0);
        anim.SetBool("Jump", true);
        jumping = true;
    }

    public void OnLog()
    {
        onLog = true;
    }

    public void OffLog()
    {
        onLog = false;
    }
    public void ResetVelocity ()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        print("Reset velocity");
    }

    void Fall ()
    {
        if (rb.velocity == new Vector3(0, 0, 0))
        {
            jumping = false;
            anim.SetBool("Jump", false);
        }
    }

    void Aiming()
    {
        print("OnAnimator triggered");
        if (aiming)
        {
            anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1);
            anim.SetIKPosition(AvatarIKGoal.LeftHand, Input.mousePosition);
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

    void Turn(int i)
    {
        if (freeze)
        {
            return;
        }
        model.transform.rotation = Quaternion.Lerp(model.transform.rotation, Quaternion.Euler(0, i, 0), Time.deltaTime * turnSpeed);
        if (goingLeft)
        {
            if (model.transform.rotation.y == 180)
            {
                turning = false;
            }
        }
        else
        {
            if (model.transform.rotation.y == 0)
            {
                turning = false; //ß
            }
        }
    }

    void MoveOff()
    {
        if (!specialLock)
        {
            anim.SetBool("Walk", false);
        }
    }

    public void SpecialLock (int i)
    {
        print("SpecialLock Called");
        switch (i)
        {
            case 0:
                specialLock = false;
                break;
            case 1:
                specialLock = true;
                break;
        }
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

    public void TakeItem(int i)
    {
        switch (i)
        {
            case 0:
                anim.SetTrigger("TakeSword");
                StartCoroutine(WaitTillDisable(backItems[selectedSword], handItems[selectedSword], 1));
                if(hud == null)
                {
                    hud = GameObject.FindGameObjectWithTag("Hud");
                }
                hud.GetComponent<PlayerHUD>().WeaponSwitching(0);
                break;
            case 1:
                anim.SetTrigger("SheatSword");
                StartCoroutine(WaitTillDisable(handItems[selectedSword], backItems[selectedSword], 1));
                break;
            case 2:
                anim.SetTrigger("TakeGun");
                StartCoroutine(WaitTillDisable(backItems[selectedGun], handItems[selectedGun], 1));
                if (hud == null)
                {
                    hud = GameObject.FindGameObjectWithTag("Hud");
                }
                hud.GetComponent<PlayerHUD>().WeaponSwitching(1);
                break;
            case 3:
                anim.SetTrigger("SheatGun");
                StartCoroutine(WaitTillDisable(handItems[selectedGun], backItems[selectedGun], 1));
                break;
        }
    }

    IEnumerator WaitTillDisable(GameObject o1, GameObject o2, int wait)
    {
        yield return new WaitForSeconds(wait);
        o1.SetActive(false);
        o2.SetActive(true);
        switching = false;
        freeze = false;
    }

    IEnumerator WaitTillSwitch(int i, int wait)
    {
        yield return new WaitForSeconds(wait);
        TakeItem(i);
    }

    public void Freeze () //Dont use this one anymore, slowly changing everything that uses it
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
    public void FreezeOn()
    {
        freeze = true;
    }
    public void FreezeOff()
    {
        freeze = false;
    }
    public void HitFreezeOn()
    {
        hitFreeze = true;
    }
    public void HitFreezeOff()
    {
        hitFreeze = false;
    }

    public void AddHP(int i)
    {
        health += i;
        if (hud == null)
        {
            hud = GameObject.FindGameObjectWithTag("Hud");
        }
        hud.GetComponent<PlayerHUD>().AddHP(health);
    }

    public void AddQubits (int i)
    {
        qubits += i;
        hud.GetComponent<PlayerHUD>().SetQubits(qubits);
    }

    public void TakeDamage (float d, bool trueDamage)
    {
        if(hud == null)
        {
            hud = GameObject.FindGameObjectWithTag("Hud");
        }
        hud.GetComponent<PlayerHUD>().HPShieldReduct(d, trueDamage, gameObject);
    }
}