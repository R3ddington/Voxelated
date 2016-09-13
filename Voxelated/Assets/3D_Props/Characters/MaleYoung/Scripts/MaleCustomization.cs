using UnityEngine;
using System.Collections;

public class MaleCustomization : MonoBehaviour {
    public string handleString;
    public int hair;
    public int skin;
    public int materialID;
    public Material[] materials;
    bool on;
    public GameObject cutScene;
    Renderer rend;

    /*
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    */

    //Change the hair color
   public void ChangeHair (int i) {
        if (!on) {
            return;
        }
        switch (i) {
            case 0:
                if(hair == 0) {
                    hair = 8;
                    PrepareMaterial();
                    return;
                }
                else hair--;
                break;
            case 1:
                if(hair == 8) {
                    hair = 0;
                    PrepareMaterial();
                    return;
                }
                else hair++;
                break;
        }
        PrepareMaterial();
    }

    //Change the skin color
   public void ChangeSkin (int i) {
        if (!on) {
            return;
        }
        switch (i) {
            case 0:
                if(skin == 0) {
                    skin = 3;
                    PrepareMaterial();
                    return;
                }
                else skin--;
                break;
            case 1:
                if(skin == 3) {
                    skin = 0;
                    PrepareMaterial();
                    return;
                }
                else skin++;
                break;
        }
        PrepareMaterial();
    }
    //Set the selected Material
    void PrepareMaterial () {
        handleString = (string)hair.ToString() + skin.ToString();
        switch (handleString) {
            case "00":
                materialID = 0;
                break;
            case "01":
                materialID = 1;
                break;
            case "02":
                materialID = 2;
                break;
            case "03":
                materialID = 3;
                break;
            case "10":
                materialID = 4;
                break;
            case "11":
                materialID = 5;
                break;
            case "12":
                materialID = 6;
                break;
            case "13":
                materialID = 7;
                break;
            case "20":
                materialID = 8;
                break;
            case "21":
                materialID = 9;
                break;
            case "22":
                materialID = 10;
                break;
            case "23":
                materialID = 11;
                break;
            case "30":
                materialID = 12;
                break;
            case "31":
                materialID = 13;
                break;
            case "32":
                materialID = 14;
                break;
            case "33":
                materialID = 15;
                break;
            case "40":
                materialID = 16;
                break;
            case "41":
                materialID = 17;
                break;
            case "42":
                materialID = 18;
                break;
            case "43":
                materialID = 19;
                break;
            case "50":
                materialID = 20;
                break;
            case "51":
                materialID = 21;
                break;
            case "52":
                materialID = 22;
                break;
            case "53":
                materialID = 23;
                break;
            case "60":
                materialID = 24;
                break;
            case "61":
                materialID = 25;
                break;
            case "62":
                materialID = 26;
                break;
            case "63":
                materialID = 27;
                break;
            case "70":
                materialID = 28;
                break;
            case "71":
                materialID = 29;
                break;
            case "72":
                materialID = 30;
                break;
            case "73":
                materialID = 31;
                break;
            case "80":
                materialID = 32;
                break;
            case "81":
                materialID = 33;
                break;
            case "82":
                materialID = 34;
                break;
            case "83":
                materialID = 35;
                break;
        }
        SetMaterial();
    }
    
    void SetMaterial () {
        rend = transform.GetComponent<Renderer>();
        rend.material = materials[materialID];
    }

    public void SetOn () {
        on = true;
    }
    public void SetOff () {
        on = false;
    }

    public void SendID () {  
        cutScene.GetComponent<OpeningCutSceneOldMan>().RetrieveID(materialID.ToString());
    }
}