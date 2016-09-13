using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerInfo : MonoBehaviour {
    public string playerName;
    public bool playerIsFemale;
    public string friendName;
    public string playerMaterialID;
    public string friendMaterialID;
	// Use this for initialization
	void Start () {

	}
	
    /*
	// Update is called once per frame
	void Update () {
	
	}
    */
    public void SetUp (int i, string s) {
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
        }
    }
}