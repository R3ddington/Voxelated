using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverBoard : MonoBehaviour {
    public bool isOn;
    public bool canMove;
    public GameObject player;
    public float speed;
    public float jumpSpeed;
    public bool jumping;
    public Transform target;
    Rigidbody rb;
    public Vector3 lastVel;
    public bool grounded;

    // Use this for initialization
    void Start () {
        Rigidbody rb = GetComponent<Rigidbody>();
    }


    public void SetOn()
    {
        FindPlayer();
        isOn = true;
    //    CustomUpdate();
        FreezePlayer();
        StartCoroutine(WaitForMove());
    }
    public void SetOff()
    {
        isOn = false;
        Rigidbody playerRB = player.GetComponent<Rigidbody>();
        player.transform.parent = null;
        playerRB.isKinematic = false;
        playerRB.detectCollisions = true;
        player.GetComponent<CharacterScript>().freeze = false;
        DontDestroyOnLoad(player);
    }
    void Update()
    {
        if (!isOn)
        {
            return;
        }
        if (canMove)
        {
            Move();
        }
        OnInput();
       // StartCoroutine(CustomUpdateDelay());
    }
    /*
    IEnumerator CustomUpdateDelay()
    {
        yield return new WaitForSeconds(0.01f);
        CustomUpdate();
    }
    */
    public void FreezePlayer()
    {
        if (player == null)
        {
            FindPlayer();
            return;
        }
        player.GetComponent<CharacterScript>().freeze = true;
       // player.GetComponent<CharacterScript>().hitFreeze = true;
        player.transform.position = target.transform.position;
        Rigidbody playerRB = player.GetComponent<Rigidbody>();
        // rb.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotationZ;
        playerRB.isKinematic = true;
        playerRB.detectCollisions = false;
        player.transform.SetParent(this.transform);
    }
    public void FindPlayer()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
        if(player == null)
        {
            StartCoroutine(WaitForPlayerCheck());
        }
        else
        {
            FreezePlayer();
        }
    }

    IEnumerator WaitForPlayerCheck ()
    {
        yield return new WaitForSeconds(1);
        FindPlayer();
    }
    IEnumerator WaitForMove()
    {
        yield return new WaitForSeconds(2);
        canMove = true;
    }

    public void Move()
    {
        // transform.position = Vector3.MoveTowards(transform.position, target.position, speed);
        transform.Translate(Vector3.right * speed);
    }
    public void OnInput()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (grounded)
            {
                Jump();
            }
        }
    }
    public void OnCollisionEnter(Collision c)
    {
        if(c.transform.tag == "Floor")
        {
            grounded = true;
        }
    }
    public void OnCollisionStay(Collision c)
    {
        if (!grounded)
        {
            grounded = true;
        }
    }
    public void OnCollisionExit(Collision c)
    {
        if (c.transform.tag == "Floor")
        {
            grounded = false;
        }
    }
    void Jump()
    {
        print("Jumping");
        //   GetComponent<Rigidbody>().AddForce(0, jumpSpeed, 0);
        GetComponent<Rigidbody>().velocity = new Vector3(0, jumpSpeed, 0);
     //   rb.velocity = new Vector3(0, jumpSpeed, 0);
        jumping = true;
    }
    public void AnimOff()
    {
        GetComponent<Animator>().enabled = false;
    }
}
