using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StartCutscene : MonoBehaviour {
    public GameObject player;
    public GameObject friend;
    public Animator anim;
    public string pName;
    public string fName;
    public Animator fade;
    public GameObject chat;
    public Transform[] sLocs; //0 = house pos player, 1 = house pos friend
    GameObject pInfo;

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
    /*
    // Update is called once per frame
    void Update()
    {

    }
    */

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
                fade.SetTrigger("FadeIn");
                StartCoroutine(Wait(i, 4));
                break;
            case 4:
                
                break;
        }
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

