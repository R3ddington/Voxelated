using UnityEngine;
using System.Collections;

public class CoopPlayerController : MonoBehaviour {

    public GameObject player;
    public Animator anim;
    public int health;
    public float speed;
    public bool isPlayer1;
    string direction;
    public Vector3 upRot;

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
        transform.Translate(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * speed * Time.deltaTime);
        DirectionCheck();
        if (anim.GetBool("Walk") == false)
        {
             anim.SetBool("Walk", true);
        }
    }
    void Movement2 ()
    {
        transform.Translate(new Vector3(Input.GetAxis("Horizontal2"), 0, Input.GetAxis("Vertical2")) * speed * Time.deltaTime);
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
}