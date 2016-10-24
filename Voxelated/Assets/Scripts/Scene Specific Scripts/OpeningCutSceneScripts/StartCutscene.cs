using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StartCutscene : MonoBehaviour {
    public GameObject player;
    public GameObject friend;
    public Animator anim;
    public string pName;
    public string fName;
    public GameObject fObject;
    public Animator fade;
    public GameObject chat;
    public Transform[] sLocs; //0 = house pos player, 1 = house pos friend
    GameObject pInfo;
    public int chatInt;
    public bool spaceable;
    public GameObject igChat;
    public Text cName;

    Renderer rend;
    // Use this for initialization
    void Start()
    {
        GameObject baby = GameObject.FindGameObjectWithTag("Baby");
        if(baby != null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            friend = GameObject.FindGameObjectWithTag("Friend");
            pInfo = GameObject.FindGameObjectWithTag("PlayerInfo");
            if (pInfo != null)
            {
                PullInfo();
            }
        }
        else
        {
            fade.SetTrigger("FadeIn");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (spaceable)
        {
            if (Input.GetButtonDown("Jump"))
            {
                ChatSkip();
            }
        }
    }


    public void PullInfo ()
    {
        pInfo.GetComponent<PlayerInfo>().SendInfo(3, gameObject);
    }

    public void GetInfo (string playerName, string friendName)
    {
        pName = playerName;
        fName = friendName;
        Prepare();
    }

    public void Prepare ()
    {
        player.transform.position = sLocs[0].position;
        friend.transform.position = sLocs[1].position;
        friend.transform.rotation = sLocs[1].rotation;
        Animations(1);
    }

    public void Animations (int i)
    {
        switch (i)
        {
            case 1:
                chat.SetActive(true);
                this.GetComponent<TextTyper>().RecieveText(pName + "  " + "hey!  wake  up!" + pName + "!" , "StartCutscene_001");
                StartCoroutine(Wait(i, 5));
                break;
            case 2:
                this.GetComponent<TextTyper>().RecieveText("Come  outside" + "  " + pName + ",  " + "I  got  to  show  you  something  awesome!", "StartCutscene_002");
                StartCoroutine(Wait(i, 5));
                break;
            case 3:
                chat.SetActive(false);
                this.GetComponent<TextTyper>().Switch(0);
                fade.SetTrigger("FadeIn");
                StartCoroutine(Wait(i, 4));
                break;
            case 4:
                fObject.SetActive(false);
                igChat.SetActive(true);
                cName.text = pName.ToString();
                this.GetComponent<TextTyper>().RecieveText(fName + "  " + "what  are you  doing  here?  it’s  almost  midnight", "StartCutscene_001");
                chatInt = i;
                ChatReady();
                break;
            case 5:
                cName.text = fName.ToString();
                this.GetComponent<TextTyper>().RecieveText("I  have  to  show  you  something!", "StartCutscene_001");
                chatInt = i;
                ChatReady();
                break;
            case 6:
                cName.text = fName.ToString();
                this.GetComponent<TextTyper>().RecieveText("Follow  Me!", "StartCutscene_001");
                chatInt = i;
                ChatReady();
                break;
            case 7:
                igChat.SetActive(false);
                break;
        }
    }

    public void ChatReady ()
    {
        spaceable = true;
    }

    public void ChatSkip ()
    {
        spaceable = false;
        chatInt++;
        Animations(chatInt);
    }

    void MovePlayer ()
    {

    }

    IEnumerator Wait (int i, int waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        i++;
        Animations(i);
    }
}

