using UnityEngine;
using System.Collections;

public class NewOpeningCutscene : MonoBehaviour {
    public GameObject pInfo;
    public string pName;
    public string fName;
    public Animator fade;
    public int step;
    bool spaceable;
    public GameObject chat;
    public string[] hisHer; //0 = player, 1 = friend
    public string[] himHer; //0 = player, 1 = friend
    public string[] heShe; //0 = player, 1 = friend

    // Use this for initialization
    void Start () {
        pInfo = GameObject.FindGameObjectWithTag("PlayerInfo");
        if (pInfo != null)
        {
            PullInfo();
        }
        else
        {
            GetInfo("player", "friend", false);
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (spaceable)
        {
            if (Input.GetButtonDown("Jump"))
            {
                ChatSkip();
            }
        }
    }

    public void PullInfo()
    {
        pInfo.GetComponent<PlayerInfo>().SendInfo(3, gameObject);
    }

    public void GetInfo(string playerName, string friendName, bool isFemale)
    {
        pName = playerName;
        fName = friendName;
        if (isFemale)
        {
            himHer[0] = "her";
            heShe[0] = "she";
            hisHer[0] = "her";
            himHer[1] = "him";
            heShe[1] = "he";
            hisHer[1] = "his";
        }
        else
        {
            himHer[0] = "him";
            heShe[0] = "he";
            hisHer[0] = "his";
            himHer[1] = "her";
            heShe[1] = "she";
            hisHer[1] = "her";
        }
        RunThrough();
    }

    public void RunThrough ()
    {
        switch (step)
        {
            case 0:
                fade.SetTrigger("FadeIn");
                StartCoroutine(Wait(3));
                break;
            case 1:
                chat.SetActive(true);
                this.GetComponent<TextTyper>().RecieveText("Welcome", "OpeningCutscene_001");
                ChatReady();
                break;
            case 2:
                this.GetComponent<TextTyper>().RecieveText("Let me tell you a tale", "OpeningCutscene_002");
                ChatReady();
                break;
            case 3:
                this.GetComponent<TextTyper>().RecieveText("Once there was a small town", "OpeningCutscene_003");
                ChatReady();
                break;
            case 4:
                this.GetComponent<TextTyper>().RecieveText("In that town there were 2 young children which lives were about to change for ever",   
                    "OpeningCutscene_004");
                ChatReady();
                break;
            case 5:
                this.GetComponent<TextTyper>().RecieveText("One night" + " " + fName + " " + "went to" + " " + pName +
                    " " + "and woke" + " " + himHer[1] + " " + "up", "OpeningCutscene_005");
                ChatReady();
                break;
            case 6:
                this.GetComponent<TextTyper>().RecieveText("They walked through the forest", "OpeningCutscene_006");
                ChatReady();
                break;
            case 7:
                this.GetComponent<TextTyper>().RecieveText("Until they reached a stonehenge", "OpeningCutscene_006");
                ChatReady();
                break;
            case 8:

                break;
        }
    }

    public void ChatReady()
    {
        spaceable = true;
    }

    public void ChatSkip()
    {
        spaceable = false;
        step++;
        RunThrough();
    }
    IEnumerator Wait(int waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        step++;
        RunThrough();
    }
}
