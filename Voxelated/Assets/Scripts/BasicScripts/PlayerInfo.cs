using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerInfo : MonoBehaviour {
    public string playerName;
    public bool playerIsFemale;
    public string friendName;
    public string playerMaterialID;
    public string friendMaterialID;
    public Material pMaterial;
    public Material fMaterial;
    public Material pYMaterial;
    public Material fYMaterial;
    public bool isAdult;
    // Use this for initialization
    void Start () {
        DontDestroyOnLoad(transform.gameObject);
    }
	
    public void SetUp (int i, string s, Material m) {
        switch (i) {
            case 0:
                playerName = s;
                break;
            case 1:
                if(s == "Yes") {
                    playerIsFemale = true;
                }
                else {
                    playerIsFemale = false;
                }
                break;
            case 2:
                friendName = s;
                break;
            case 3:
                playerMaterialID = s;
                break;
            case 4:
                friendMaterialID = s;
                break;
            case 5:
                pMaterial = m;
                break;
            case 6:
                fMaterial = m;
                break;
            case 7:
                pYMaterial = m;
                break;
            case 8:
                fYMaterial = m;
                break;
            case 9:
                if (s == "Yes")
                {
                    isAdult = true;
                }
                else
                {
                    isAdult = false;
                }
                break;
        }
    }
    public void SendInfo(int id, GameObject target)
    {
        switch (id)
        {
            case 0:
                //TutorialScript request
                target.GetComponent<TutorialScript>().GetInfo(playerName, friendName, playerIsFemale, pMaterial);
                break;
         /*   case 1:
                target.GetComponent<StartCutscene>().GetInfo(playerName, friendName, playerIsFemale, pYMaterial);
                break;
          */
            case 2:
                target.GetComponent<PreparePlayer>().GetInfo(playerName, friendName, playerIsFemale, pMaterial, fMaterial, isAdult);
                break;
            case 3:
                target.GetComponent<NewOpeningCutscene>().GetInfo(playerName, friendName, playerIsFemale);
                break;
        }
    }
}