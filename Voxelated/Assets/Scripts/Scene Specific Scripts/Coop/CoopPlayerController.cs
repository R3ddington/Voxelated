using UnityEngine;
using System.Collections;

public class CoopPlayerController : MonoBehaviour {

    public GameObject player;
    public Animator anim;
    public int health;
    public int[] speed; //0 = using speed, 1 = normal speed, 2 = sprint speed
    public bool isPlayer1;
    string direction;
    public Vector3 upRot;
    public GameObject katana;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        ButtonInput();
	}

    void ButtonInput()
    {
        if (isPlayer1)
        {
            if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
            {
                Movement();
            }
            else
            {
                MoveOff();
            }
            if (Input.GetButtonDown("LShift"))
            {
                //do sprint speed
                speed[0] = speed[2];
                anim.SetBool("Run",true);
            }
            if (Input.GetButtonUp("LShift"))
            {
                speed[0] = speed[1];
                anim.SetBool("Run", false);
            }
            if (Input.GetButtonDown("Q"))
            {
                anim.SetTrigger("Slash");
                katana.GetComponent<KatanaScript>().SetOn();
                StartCoroutine(KatanaCooldown());
            }
        }
        else
        {
            if (Input.GetAxis("Horizontal2") != 0 || Input.GetAxis("Vertical2") != 0)
            {
                Movement2();
            }
            else
            {
                MoveOff();
            }
            if (Input.GetButtonDown("RShift"))
            {
                speed[0] = speed[2];
                anim.SetBool("Run", true);
            }
            if (Input.GetButtonUp("RShift"))
            {
                speed[0] = speed[1];
                anim.SetBool("Run", false);
            }
            if (Input.GetButtonDown("Fire1"))
            {
                anim.SetTrigger("Slash");
                katana.GetComponent<KatanaScript>().SetOn();
                StartCoroutine(KatanaCooldown());
            }
        }
    }

    void MoveOff ()
    {
        if (anim.GetBool("Walk"))
        {
            anim.SetBool("Walk", false);
        }
    }

    void Movement () {
        transform.Translate(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * speed[0] * Time.deltaTime);
        DirectionCheck();
        if (anim.GetBool("Walk") == false)
        {
             anim.SetBool("Walk", true);
        }
    }
    void Movement2 ()
    {
        transform.Translate(new Vector3(Input.GetAxis("Horizontal2"), 0, Input.GetAxis("Vertical2")) * speed[0] * Time.deltaTime);
        DirectionCheck2();
        if (anim.GetBool("Walk") == false)
        {
            anim.SetBool("Walk", true);
        }
    }

    void DirectionCheck ()
    {
        if (Input.GetButton("W"))
        {
            Vector3 temp = player.transform.localEulerAngles;
            temp.y = 0f;
            player.transform.localEulerAngles = temp;
        }
        if (Input.GetButton("S"))
        {
            Vector3 temp = player.transform.localEulerAngles;
            temp.y = 180f;
            player.transform.localEulerAngles = temp;
        }
        if (Input.GetButton("A"))
        {
            Vector3 temp = player.transform.localEulerAngles;
            temp.y = -90f;
            player.transform.localEulerAngles = temp;
        }
        if (Input.GetButton("D"))
        {
            Vector3 temp = player.transform.localEulerAngles;
            temp.y = 90f;
            player.transform.localEulerAngles = temp;
        }
    }

    void DirectionCheck2 ()
    {
        if (Input.GetButton("Up"))
        {
            Vector3 temp = player.transform.localEulerAngles;
            temp.y = 0f;
            player.transform.localEulerAngles = temp;
        }
        if (Input.GetButton("Down"))
        {
            Vector3 temp = player.transform.localEulerAngles;
            temp.y = 180f;
            player.transform.localEulerAngles = temp;
        }
        if (Input.GetButton("Left"))
        {
            Vector3 temp = player.transform.localEulerAngles;
            temp.y = -90f;
            player.transform.localEulerAngles = temp;
        }
        if (Input.GetButton("Right"))
        {
            Vector3 temp = player.transform.localEulerAngles;
            temp.y = 90f;
            player.transform.localEulerAngles = temp;
        }
    }
    IEnumerator KatanaCooldown()
    {
        yield return new WaitForSeconds(1);
        katana.GetComponent<KatanaScript>().SetOff();
    }
}