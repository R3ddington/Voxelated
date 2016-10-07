using UnityEngine;
using System.Collections;

public class TutorialScript : MonoBehaviour {
    /*
     * If isFemale = false, destroy the female object, set player to the correct gender 
     * Use male for now until female textures are done
     */
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
    Renderer rend;
    public Animator fade;
    // Use this for initialization
    void Start () {
        pInfo = GameObject.FindGameObjectWithTag("PlayerInfo");
        if(pInfo != null)
        {
            PullInfo();
        }
        else
        {
            GetInfo("FakePlayer", "FakeFriend", true, standardMaterial);
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void PullInfo()
    {
        pInfo.GetComponent<PlayerInfo>().SendInfo(0, gameObject);
    }

    public void GetInfo(string i_pName, string i_fName, bool i_isFemale, Material i_pMaterial)
    {
        pName = i_pName;
        fName = i_fName;
        isFemale = i_isFemale;
        pMaterial = i_pMaterial;
        PreparePlayer();
    }
    
    public void PreparePlayer ()
    {
        if (isFemale)
        {
            Destroy(male);
            player = female;
            pM = fM;
        }
        else
        {
            Destroy(female);
            player = male;
            pM = mM;
        }
        rend = pM.transform.GetComponent<Renderer>();
        rend.material = pMaterial;
        ActivateCamera();
    }

    void ActivateCamera()
    {
        this.GetComponent<CameraFollowScript>().SetPlayer(player);
        this.GetComponent<CameraFollowScript>().SetActive();
        fade.SetTrigger("Tut");
    }
}
