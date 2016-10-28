using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PreparePlayer : MonoBehaviour {

    public GameObject[] female;
    public GameObject[] male;
    public GameObject player;
    public GameObject friend;
    public GameObject[] mM;
    public GameObject[] fM;
    public GameObject pM;
    public GameObject friendM;
    public Material pMaterial;
    public Material fMaterial;
    public bool isFemale;
    public string pName;
    public string fName;
    public GameObject pInfo;
    public bool isAdult;
    public Material standardMaterial;
    Renderer rend;
    Renderer fRend;
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
          //  GetInfo("FakePlayer", "FakeFriend", true, standardMaterial, true);
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
        pInfo.GetComponent<PlayerInfo>().SendInfo(2, gameObject);
    }

    public void GetInfo(string i_pName, string i_fName, bool i_isFemale, Material i_pMaterial, Material i_fMaterial, bool i_isAdult)
    {
        pName = i_pName;
        fName = i_fName;
        isFemale = i_isFemale;
        pMaterial = i_pMaterial;
        fMaterial = i_fMaterial;
        isAdult = i_isAdult;
        Prepare();
    }

    public void Prepare()
    {
        if (!isAdult)
        {
            if (isFemale)
            {
                player = female[1];
                friend = male[1];
                pM = fM[1];
                friendM = mM[1];
            }
            else
            {
                friend = female[1];
                player = male[1];
                pM = mM[1];
                friendM = fM[1];
            }
        }
        else
        {
            if (isFemale)
            {
                friend = male[1];
                player = female[0];
                pM = fM[0];
                friendM = mM[0];
            }
            else
            {
                player = male[0];
                pM = mM[0];
                friendM = fM[0];
            }
        }
        
        rend = pM.transform.GetComponent<Renderer>();
        rend.material = pMaterial;
        DontDestroyOnLoad(player);

        fRend = friendM.transform.GetComponent<Renderer>();
        fRend.material = fMaterial;
        friend.transform.tag = "Friend";
        DontDestroyOnLoad(friend);

        SceneManager.LoadScene(5);
    }
}
