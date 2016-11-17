using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class NewOpeningCutscene : MonoBehaviour {
    public GameObject pInfo;
    public string pName;
    public string fName;
    public Animator fade;
    public int step;
    public bool spaceable;
    public GameObject chat;
    public string[] hisHer; //0 = player, 1 = friend
    public string[] himHer; //0 = player, 1 = friend
    public string[] heShe; //0 = player, 1 = friend
    public GameObject[] show; //0 = town, 1 = forest, 2 = stonehenge, 3 = rift, 4 = wizard room
    public GameObject[] players; //0 = town female, 1 = town male, 2 = stongehedge female, 3 = stonehedge male, 4 = female down, 5 = male down, 
                                 //6 = female bed, 7 = male bed
    public Animator[] playerAnimations; //0 = town female, 1 = town male, 2 = forest female, 3 = forest male, 4 = stongehedge female, 5 = stonehedge male
                                        // 6 = female bed, 7 = male bed
    bool m;
    int pM = 0;
    public Transform riftLoc;
    bool female;

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
            female = true;
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
                ChangeChatColor(2);
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
            /*
            case 6:
                this.GetComponent<TextTyper>().RecieveText(fName + " " + "told" + " " + pName + " " + "that" + " " +
                    heShe[1] + " " + "found something awesome and that" + " " + heShe[0] + " " + "had to follow" + " " + himHer[1]  , "OpeningCutscene_006");
                break;
            */
            case 6:
                ChangeChatColor(1);
                this.GetComponent<TextTyper>().RecieveText("Hey" + " " + pName + " " + ", follow me, I found something awesome!" , "OpeningCutscene_006");
                break;
            case 7:
                ChangeChatColor(2);
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
                ChangeChatColor(1);
                this.GetComponent<TextTyper>().RecieveText("hey" + " " + pName + "," + " " + "we will always be together, right?", "OpeningCutscene_010");
                break;
            case 11:
                ChangeChatColor(0);
                this.GetComponent<TextTyper>().RecieveText("always", "OpeningCutscene_011");
                break;
            case 12:
                show[3].SetActive(true);
                ChangeChatColor(3);
                this.GetComponent<TextTyper>().RecieveText("huh!", "OpeningCutscene_012");
                StartCoroutine(Wait(3));
                break;
            case 13:
                if (!m)
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
                if (!m)
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
                ChangeChatColor(1);
                this.GetComponent<TextTyper>().RecieveText(pName +  " " + "heeeeeelp!", "OpeningCutscene_015");
                break;
            case 16:
                ChangeChatColor(0);
                this.GetComponent<TextTyper>().RecieveText(fName + " " + "Hold on! I can't move!", "OpeningCutscene_016");
                break;
            case 17:
                this.GetComponent<TextTyper>().RecieveText(fName + "!" + " " + "Noooooooo!", "OpeningCutscene_017");
                StartCoroutine(Wait(1));
                break;
            case 18:
                ChangeChatColor(1);
                Animator riftAnim = show[3].GetComponent<Animator>();
                riftAnim.SetTrigger("Disapear");
                this.GetComponent<TextTyper>().RecieveText("Whaaaaaaaa!", "OpeningCutscene_018");
                StartCoroutine(Wait(2));
                break;
            case 19:
                ChangeChatColor(0);
                this.GetComponent<TextTyper>().RecieveText("N-n-no..." + " " + fName + " " + "please...", "OpeningCutscene_019");
                show[3].SetActive(false);
                break;
            case 20:
                this.GetComponent<TextTyper>().RecieveText("Come back... please...", "OpeningCutscene_020");
                break;
            case 21:
                this.GetComponent<TextTyper>().RecieveText("Ple....", "OpeningCutscene_021");
                step++;
                break;
            case 22:
                // this.GetComponent<TextTyper>().RecieveText(pName + " " + "fainted", "OpeningCutscene_022");
                break;
            case 23:
                fade.SetTrigger("FadeOut");
                StartCoroutine(Wait(3));
                break;
            case 24:
                show[2].SetActive(false);
                show[4].SetActive(true);
                if (!m)
                {
                    players[6].SetActive(true);
                }
                else
                {
                    players[7].SetActive(true);
                }
                fade.SetTrigger("FadeIn");
                this.GetComponent<TextTyper>().RecieveText("...", "OpeningCutscene_024");
                StartCoroutine(Wait(3));
                break;
            case 25:
                this.GetComponent<TextTyper>().RecieveText("ugh... eh...", "OpeningCutscene_025");
                break;
            case 26:
                ChangeChatColor(4);
                this.GetComponent<TextTyper>().RecieveText("Hey, take it easy you are still wounded", "OpeningCutscene_026");
                break;
            case 27:
                this.GetComponent<TextTyper>().RecieveText("I found you at the stonehenge", "OpeningCutscene_027");
                break;
            case 28:
                ChangeChatColor(0);
                this.GetComponent<TextTyper>().RecieveText(fName + "!" + " " + "Did you see" + " " + himHer[1] + "?", "OpeningCutscene_028");
                break;
            case 29:
                ChangeChatColor(4);
                this.GetComponent<TextTyper>().RecieveText("No... was" + " " + heShe[1] + " " + "with you?", "OpeningCutscene_029");
                break;
            case 30:
                ChangeChatColor(0);
                this.GetComponent<TextTyper>().RecieveText("yes... w-w-we... we were there and then there was a huge flash of light...",
                    "OpeningCutscene_030");
                break;
            case 31:
                this.GetComponent<TextTyper>().RecieveText("And then this... this... i don't know what it was...", "OpeningCutscene_031");
                break;
            case 32:
                this.GetComponent<TextTyper>().RecieveText("It took" + " " + himHer[1] + "...", "OpeningCutscene_032");
                break;
            case 33:
                ChangeChatColor(4);
                this.GetComponent<TextTyper>().RecieveText("No... no... no! this is impossible... it can't be...", "OpeningCutscene_033");
                break;
            case 34:
                this.GetComponent<TextTyper>().RecieveText("Are you really sure that you saw this?!", "OpeningCutscene_034");
                break;
            case 35:
                ChangeChatColor(0);
                this.GetComponent<TextTyper>().RecieveText("y-y-yes...", "OpeningCutscene_035");
                break;
            case 36:
                ChangeChatColor(4);
                this.GetComponent<TextTyper>().RecieveText("Listen, long ago there was a tale about a legendary beast", "OpeningCutscene_036");
                break;
            case 37:
                this.GetComponent<TextTyper>().RecieveText("It would travel between universums and devour anything on its path", "OpeningCutscene_037");
                break;
            case 38:
                this.GetComponent<TextTyper>().RecieveText("However, this was not just a fairy tail, it was real", "OpeningCutscene_038");
                break;
            case 39:
                this.GetComponent<TextTyper>().RecieveText("Every 7 years it would open a rift somewhere on earth and rampage until it ate enough",
                    "OpeningCutscene_039");
                break;
            case 40:
                this.GetComponent<TextTyper>().RecieveText("The rift always opens at the same location, which is on this island", "OpeningCutscene_040");
                break;
            case 41:
                this.GetComponent<TextTyper>().RecieveText("35 years ago we finally succeeded in slaying the beast", "OpeningCutscene_041");
                break;
            case 42:
                this.GetComponent<TextTyper>().RecieveText("Atleast that's what we thought", "OpeningCutscene_042");
                break;
            case 43:
                this.GetComponent<TextTyper>().RecieveText("If it opened a new rift it means that it survived and will return", "OpeningCutscene_043");
                break;
            case 44:
                this.GetComponent<TextTyper>().RecieveText("This is bad... I'm old and all the others who fought the beast with me died ages ago",
                    "OpeningCutscene_044");
                break;
            case 45:
                ChangeChatColor(0);
                this.GetComponent<TextTyper>().RecieveText("L..let me fight it....", "OpeningCutscene_045");
                break;
            case 46:
                ChangeChatColor(4);
                this.GetComponent<TextTyper>().RecieveText("What?", "OpeningCutscene_046");
                step += 2; //add 2 to skip the comented lines below
                break;
            /*
            case 47:
                this.GetComponent<TextTyper>().RecieveText("I will kill it", "OpeningCutscene_047");
                break;
            case 48:
                this.GetComponent<TextTyper>().RecieveText("You are way too weak and young to do that!", "OpeningCutscene_048");
                break;
            */
            case 49:
                ChangeChatColor(0);
                this.GetComponent<TextTyper>().RecieveText("You said it opens once each 7 years right?", "OpeningCutscene_049");
                break;
            case 50:
                this.GetComponent<TextTyper>().RecieveText("I will be 19 then, I have to rescue" + " " + himHer[1], "OpeningCutscene_050");
                break;
            case 51:
                ChangeChatColor(4);
                this.GetComponent<TextTyper>().RecieveText("Very well, Who am I to stop you, I did the same thing years ago...", "OpeningCutscene_051");
                break;
            case 52:
                this.GetComponent<TextTyper>().RecieveText("Rest and heal up, after that I will start training you to fight whatever you will find inside there"
                    , "OpeningCutscene_052");
                break;
            case 53:
                this.GetComponent<TextTyper>().RecieveText("You can have the armor and weapons I found during my adventure in there", "OpeningCutscene_053");
                break;
            /*
            case 54:
                this.GetComponent<TextTyper>().RecieveText("How will we be able to get from the rift after I found" + " " + fName + "?",
                    "OpeningCutscene_054");
                break;
            case 55:
                this.GetComponent<TextTyper>().RecieveText("Don't worry about that, I will use my magic to keep my rift open until you are back",
                    "OpeningCutscene_055");
                break;
            */
            case 54:
                this.GetComponent<TextTyper>().RecieveText("Rest now child, you have a long and rough path ahead of you", "OpeningCutscene_056");
                break;
            case 55:
                fade.SetTrigger("FadeOut");
                StartCoroutine(Wait(3));
                break;
            case 56:
                SceneManager.LoadScene(3);
                break;
        }
    }

    public void ChatReady()
    {
        if (!(step == 12 || step == 13 || step == 14 || step == 17 || step == 18 || step == 23 || step == 24 || step == 55 || step == 56)) 
            //Not space able during these cases
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

    public void ChangeChatColor(int i)
    {
        switch (i)
        {
            //Player chat
            case 0:
                if (female)
                {
                    this.GetComponent<TextTyper>().SetColor("pink");
                }
                else
                {
                    this.GetComponent<TextTyper>().SetColor("blue");
                }
                break;
            //Friend chat
            case 1:
                if (female)
                {
                    this.GetComponent<TextTyper>().SetColor("blue");
                }
                else
                {
                    this.GetComponent<TextTyper>().SetColor("pink");
                }
                break;
            case 2:
                this.GetComponent<TextTyper>().SetColor("green");
                break;
            case 3:
                this.GetComponent<TextTyper>().SetColor("cyan");
                break;
            case 4:
                this.GetComponent<TextTyper>().SetColor("yellow");
                break;
        }
    }
}