using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StartCutscene : MonoBehaviour {
    public GameObject female;
    public GameObject male;
    public GameObject player;
    public GameObject mM;
    public GameObject fM;
    public GameObject pM;
    public Material pMaterial;
    public bool isFemale;
    public string pName;
    public string fName;
    public GameObject pInfo;
    public Material standardMaterial;
    public Animator anim;
    public Animator mAnim;
    public Animator fAnim;
    public Animator fade;
    public GameObject chat;

    Renderer rend;
    // Use this for initialization
    void Start()
    {
        pInfo = GameObject.FindGameObjectWithTag("PlayerInfo");
        if (pInfo != null)
        {
            PullInfo();
        }
        else
        {
            GetInfo("FakePlayer", "FakeFriend", true, standardMaterial);
        }
    }
    /*
    // Update is called once per frame
    void Update()
    {

    }
    */
    public void PullInfo()
    {
        pInfo.GetComponent<PlayerInfo>().SendInfo(1, gameObject);
    }

    public void GetInfo(string i_pName, string i_fName, bool i_isFemale, Material i_pMaterial)
    {
        pName = i_pName;
        fName = i_fName;
        isFemale = i_isFemale;
        pMaterial = i_pMaterial;
        PreparePlayer();
    }

    public void PreparePlayer()
    {
        if (isFemale)
        {
            Destroy(male);
            player = female;
            pM = fM;
            anim = fAnim;
        }
        else
        {
            Destroy(female);
            player = male;
            pM = mM;
            anim = mAnim;
        }
        rend = pM.transform.GetComponent<Renderer>();
        rend.material = pMaterial;
        Animations(0);
    }

    public void Animations (int i)
    {
        switch (i)
        {
            case 0:
                anim.SetTrigger("Sitting");
                StartCoroutine(Wait(i, 5));
                break;
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
                anim.SetTrigger("StandUp");
                StartCoroutine(Wait(i, 4));
                break;
            case 4:
                Vector3 tempV = new Vector3(-162, 0, - 187);
                player.GetComponent<PlayerMoving>().Move(tempV);
                anim.SetBool("Walk", true);
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

