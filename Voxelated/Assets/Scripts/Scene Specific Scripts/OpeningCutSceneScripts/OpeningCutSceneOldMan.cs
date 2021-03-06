﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OpeningCutSceneOldMan : MonoBehaviour {
    public Animator spotlights;
    public List<string> textList = new List<string>();
    public GameObject textField;
    public GameObject chatBar;
    public GameObject mainCharCustomizer;
    public GameObject friendCustomizer;
    public GameObject male;
    public GameObject female;
    public GameObject maleS;
    public GameObject femaleS;
    public GameObject characterLights;
    public GameObject oldman;
    int chatInt;
    bool spaceAble;
    string playerName;
    string friendName;
    bool isFemale;
    public Text pN;
    public Text fN;
    public GameObject[] namePages; //0 = pNamePage, 1 = fNamePage
    public GameObject confirmPage;
    public Text confirmMessage;
    public Text friendTell;
    public GameObject friendTellPage;
    bool fNamed;
    bool lock001;
    bool lock002;
    string himOrHer;
    public GameObject playerInfo;
    public string playerMaterial;
    public string friendMaterial;
    public GameObject hParticles;
    public Transform hParticlePos;
    public Material pMaterial;
    public Material fMaterial;
    public Material pYMaterial;
    public Material fYMaterial;
    public Material[] maleMaterial;
    public Material[] femaleMaterial;

    public AudioSource aSource;
    public AudioClip[] clip;

    public GameObject forceLoader;
    public bool isReloading;



    // Use this for initialization
    void Start () {
        forceLoader = GameObject.FindGameObjectWithTag("ForceLoad");
        if(forceLoader != null)
        {
            isReloading = true;
            LoadPrev();
            return;
        }
        StartCoroutine(StartWaitTimer(3, "WaitForText"));
        aSource = gameObject.GetComponent<AudioSource>();
        aSource.clip = clip[0];
    }
	
	// Update is called once per frame
	void Update () {
        ButtonInput();
	}

    public void LoadPrev ()
    {
        forceLoader.GetComponent<SaveSystem>().LoadData(transform.gameObject);
    }


    public void GetLoad(string pN, bool pFemale, string fN, string pM, string fM)
    {
        playerName = pN;
        isFemale = pFemale;
        friendName = fN;
        playerMaterial = pM;
        friendMaterial = fM;
        int playerMaterialInt;
        int.TryParse(pM, out playerMaterialInt);
        int friendMaterialInt;
        int.TryParse(fM, out friendMaterialInt);
        if (isFemale)
        {
            pMaterial = femaleMaterial[playerMaterialInt];
            fMaterial = maleMaterial[friendMaterialInt];
        }
        else
        {
            pMaterial = maleMaterial[playerMaterialInt];
            fMaterial = femaleMaterial[friendMaterialInt];
        }
        // SceneManager.LoadScene(3);
        PrepareInfo();
    }

    void ButtonInput () {
        if (Input.GetButtonDown("Jump")) {
            if (spaceAble) {
                ChatBarButton(chatInt);
            }
        }
    }

    IEnumerator StartWaitTimer (int i, string s) {
        yield return new WaitForSeconds(i);
        switch (s) {
            /*
            case "WaitOnStart":
             //   LightsOn();
             //   print("Turned Lights On");
                break;
                */
            case "WaitForText":
                chatBar.SetActive(true);
                textField.GetComponent<TextTyper>().RecieveText(textList[0], "00");
                chatInt++;
                spaceAble = true;
                break;
            case "WaitForCustom":
                if (!lock001) {
                 //   oldman.SetActive(false);
                    male.SetActive(true);
                    isFemale = false;
                    maleS.GetComponent<MaleCustomization>().SetOn();
                    mainCharCustomizer.SetActive(true);
                    characterLights.SetActive(true);
                    print("actived player customizer");
                    lock001 = true;
                }
                break;
        }
    }

   public void ChangeGender (int i) {
        PlayClickSound();
        switch (i) {
            case 0:
                female.SetActive(false);
                male.SetActive(true);
                maleS.GetComponent<MaleCustomization>().SetOn();
                femaleS.GetComponent<MaleCustomization>().SetOff();
                isFemale = false;
                break;
            case 1:
                maleS.GetComponent<MaleCustomization>().SetOff();
                femaleS.GetComponent<MaleCustomization>().SetOn();
                male.SetActive(false);
                female.SetActive(true);
                isFemale = true;
                break;
        }
    }

    void LightsOn () {
        spotlights.SetTrigger("On");
        StartCoroutine(StartWaitTimer(2, "WaitForText"));
    }

    void LightsOff () {
        spotlights.SetTrigger("Off");
    }

    public void SpaceToTrue () {
        chatInt++;
        spaceAble = true;
    }

    public void FinishPlayer () {
        PlayClickSound();
        if (isFemale) {
            femaleS.GetComponent<MaleCustomization>().SendID();
        }
        else {
            maleS.GetComponent<MaleCustomization>().SendID();
        }
        mainCharCustomizer.SetActive(false);
        namePages[0].SetActive(true);
    }

    public void FinishFriend () {
        PlayClickSound();
        if (isFemale) {
            maleS.GetComponent<MaleCustomization>().SendID();
        }
        else {
            femaleS.GetComponent<MaleCustomization>().SendID();
        }
        friendCustomizer.SetActive(false);
        namePages[1].SetActive(true);
        fNamed = true;
    }

    public void PlayerName () {
        PlayClickSound();
        playerName = pN.text.ToString();
        if(!(playerName == "" || playerName == " ")) {
            namePages[0].SetActive(false);
            confirmPage.SetActive(true);
            confirmMessage.text = "So your name is " + playerName + "?";
            if(playerName == "Harambe" || playerName == "harambe")
            {
                Instantiate(hParticles, hParticlePos.position, Quaternion.identity);
            }
        }
    }

    public void FriendName () {
        PlayClickSound();
        friendName = fN.text.ToString();
        if (!(playerName == "" || playerName == " ")) {
            namePages[1].SetActive(false);
            confirmPage.SetActive(true);
            confirmMessage.text = "Your friends name is " + friendName + "?";
        }
    }

    public void ConfirmNames (int i) {
        PlayClickSound();
        confirmPage.SetActive(false);
        if (fNamed) {
            i += 2;
        }
        switch (i) {
            case 0:
                namePages[0].SetActive(true);
                break;
            case 1:
                friendTellPage.SetActive(true);
                if (isFemale) {
                    himOrHer = "him";
                }
                else {
                    himOrHer = "her";
                }
                friendTell.text = "Make your friend";
                spaceAble = true;
                break;
            case 2:
                namePages[1].SetActive(true);
                break;
            case 3:
                PrepareInfo();
                break;
        }
    }

    void ChatBarButton (int i) {
        switch (i) {
            /*
            case 1:
                textField.GetComponent<TextTyper>().RecieveText(textList[chatInt], "0" + chatInt.ToString());
                //   spaceAble = false;
                chatInt++;
                break;
            */
            case 1:
                chatBar.SetActive(false);
               // LightsOff();
                StartCoroutine(StartWaitTimer(2, "WaitForCustom"));
                spaceAble = false;
                chatInt++;
                break;
            case 2:
                friendCustomizer.SetActive(true);
                friendTellPage.SetActive(false);
                if (isFemale) {
                    male.SetActive(true);
                    female.SetActive(false);
                    maleS.GetComponent<MaleCustomization>().SetOn();
                    femaleS.GetComponent<MaleCustomization>().SetOff();
                }
                else {
                    female.SetActive(true);
                    male.SetActive(false);
                    maleS.GetComponent<MaleCustomization>().SetOff();
                    femaleS.GetComponent<MaleCustomization>().SetOn();
                }
                spaceAble = false;
                break;
        }
    }

    public void RetrieveID (string s, int i, Material m) {
        
        if (!lock002) {
            if (isFemale)
            {
                pMaterial = femaleMaterial[i];
            }
            else
            {
                pMaterial = maleMaterial[i];
            }
            pYMaterial = m;
            playerMaterial = s;
            lock002 = true;
        }
        else {
            friendMaterial = s;
            if (isFemale)
            {
                fMaterial = maleMaterial[i];
            }
            else
            {
                fMaterial = femaleMaterial[i];
            }
            fYMaterial = m;
        }
    }

    void PrepareInfo () {
        print("Sending Player info");
        SendPlayerInfo(0, playerName, null);
        if (isFemale) {
            SendPlayerInfo(1, "Yes", null);
        }
        else {
            SendPlayerInfo(1, "No", null);
        }
        SendPlayerInfo(2, friendName, null);
        SendPlayerInfo(3, playerMaterial, null);
        SendPlayerInfo(4, friendMaterial, null);
        SendPlayerInfo(5, null, pMaterial);
        SendPlayerInfo(6, null, fMaterial);
        SendPlayerInfo(7, null, pYMaterial);
        SendPlayerInfo(8, null, fYMaterial);
        SendPlayerInfo(9, "No", null);
        SendPlayerInfo(10, null, null);
    }

    void SendPlayerInfo (int i, string s, Material m) {
        if(i != 10)
        {
            print(i.ToString() + " " + s);
            playerInfo.GetComponent<PlayerInfo>().SetUp(i, s, m);
        }
        if(i == 10)
        {
            characterLights.SetActive(false);
            //   LightsOff();
            StartCoroutine(GoToCutScene());
        }
    }
    IEnumerator GoToCutScene()
    {
        yield return new WaitForSeconds(4);
        if (isReloading)
        {
            SceneManager.LoadScene(3);
        }
        else
        {
            SceneManager.LoadScene(6);
        }   
    }
    public void PlayClickSound()
    {
        aSource.Play();
    }
}