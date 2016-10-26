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
    public GameObject[] show; //0 = town, 1 = forest, 2 = stonehenge, 3 = rift
    public GameObject[] players; //0 = town female, 1 = town male, 2 = stongehedge female, 3 = stonehedge male, 4 = female down, 5 = male down
    public Animator[] playerAnimations; //0 = town female, 1 = town male, 2 = forest female, 3 = forest male, 4 = stongehedge female, 5 = stonehedge male
    bool m;
    int pM = 0;
    public Transform riftLoc;

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
            m = true;
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
                break;
            case 2:
                this.GetComponent<TextTyper>().RecieveText("Let me tell you a tale", "OpeningCutscene_002");
                break;
            case 3:
                this.GetComponent<TextTyper>().RecieveText("Once there was a small town", "OpeningCutscene_003");
                show[0].SetActive(true);
                break;
            case 4:
                this.GetComponent<TextTyper>().RecieveText("In that town there were 2 young children which lives were about to change for ever",   
                    "OpeningCutscene_004");
                break;
            case 5:
                this.GetComponent<TextTyper>().RecieveText("One night" + " " + fName + " " + "went to" + " " + pName +
                    " " + "and woke" + " " + himHer[0] + " " + "up", "OpeningCutscene_005");
                if (!m)
                {
                    pM = 1;
                }
                else
                {
                    pM = 0;
                }
                players[pM].SetActive(true);
                playerAnimations[pM].SetBool("Walk", true);
                break;
            case 6:
                this.GetComponent<TextTyper>().RecieveText(fName + " " + "told" + " " + pName + " " + "that" + " " +
                    heShe[1] + " " + "found something awesome and that" + " " + heShe[0] + " " + "had to follow" + " " + himHer[1]  , "OpeningCutscene_006");
                break;
            case 7:
                this.GetComponent<TextTyper>().RecieveText("They walked through the forest", "OpeningCutscene_007");
                show[0].SetActive(false);
                show[1].SetActive(true);
                playerAnimations[2].SetBool("Walk", true);
                playerAnimations[3].SetBool("Walk", true);
                break;
            case 8:
                this.GetComponent<TextTyper>().RecieveText("Until they reached a stonehenge", "OpeningCutscene_008");
                show[1].SetActive(false);
                show[2].SetActive(true);
                break;
            case 9:
                this.GetComponent<TextTyper>().RecieveText(fName + " " + "showed" + " " + pName + " " +  "the strange rocks" + " " + heShe[1] + " " + "found before" 
                    , "OpeningCutscene_009");
                break;
            case 10:
                this.GetComponent<TextTyper>().RecieveText("hey" + " " + pName + "," + " " + "we will always be together, right?" + " " + 
                    fName + " " + "asked" , "OpeningCutscene_010");
                break;
            case 11:
                this.GetComponent<TextTyper>().RecieveText("always," + " " + pName + " " + "replied", "OpeningCutscene_011");
                break;
            case 12:
                show[3].SetActive(true);
                this.GetComponent<TextTyper>().RecieveText("huh!", "OpeningCutscene_012");
                StartCoroutine(Wait(3));
                break;
            case 13:
                if (m)
                {
                    playerAnimations[5].SetBool("MaleSuck", true);
                    playerAnimations[4].SetBool("Stun", true);

                }
                else
                {
                    playerAnimations[4].SetBool("FemaleSuck", true);
                    playerAnimations[5].SetBool("Stun", true);
                }
                StartCoroutine(Wait2(0.6f));
                break;
            case 14:
                if (m)
                {
                    playerAnimations[5].SetBool("MaleSuck", true);
                    players[5].SetActive(true);
                    players[3].SetActive(false);
                }
                else
                {
                    playerAnimations[4].SetBool("FemaleSuck", true);
                    players[4].SetActive(true);
                    players[2].SetActive(false);
                }
                StartCoroutine(Wait2(0.6f));
                break;
            case 15:
                this.GetComponent<TextTyper>().RecieveText(pName +  " " + "heeeeeelp!", "OpeningCutscene_015");
                break;
            case 16:
                this.GetComponent<TextTyper>().RecieveText(fName + " " + "Hold on! I can't move!", "OpeningCutscene_016");
                break;
            case 17:
                this.GetComponent<TextTyper>().RecieveText(fName + "!" + " " + "Noooooooo!", "OpeningCutscene_017");
                StartCoroutine(Wait(1));
                break;
            case 18:
                Animator riftAnim = show[3].GetComponent<Animator>();
                riftAnim.SetTrigger("Disapear");
                this.GetComponent<TextTyper>().RecieveText("Whaaaaaaaa!", "OpeningCutscene_018");
                StartCoroutine(Wait(2));
                break;
            case 19:
                this.GetComponent<TextTyper>().RecieveText("N-n-no..." + " " + fName + " " + "please...", "OpeningCutscene_019");
                break;
            case 20:
                this.GetComponent<TextTyper>().RecieveText("Come back... please...", "OpeningCutscene_020");
                break;
            case 21:
                this.GetComponent<TextTyper>().RecieveText("Ple....", "OpeningCutscene_021");
                break;
            case 22:
                this.GetComponent<TextTyper>().RecieveText(pName + " " + "fainted", "OpeningCutscene_022");
                break;
            case 23:
                fade.SetTrigger("FadeOut");
                StartCoroutine(Wait(3));
                break;
            case 24:
                show[3].SetActive(false);
                show[2].SetActive(false);
                fade.SetTrigger("FadeIn");
                this.GetComponent<TextTyper>().RecieveText("...", "OpeningCutscene_024");
                StartCoroutine(Wait(3));
                break;
        }
    }

    public void ChatReady()
    {
        if (!(step == 12 || step == 13 || step == 14 || step == 17 || step == 18 || step == 23 || step == 24))  //Not space able during these cases
        {
            spaceable = true;
        }
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
    IEnumerator Wait2(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        step++;
        RunThrough();
    }
}