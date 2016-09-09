using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class OpeningCutSceneOldMan : MonoBehaviour {
    public Animator spotlights;
    public List<string> textList = new List<string>();
    public GameObject textField;
    public GameObject chatBar;
    public GameObject mainCharCustomizer;
    public GameObject male;
    public GameObject female;
    public GameObject maleS;
    public GameObject femaleS;
    public GameObject characterLights;
    public GameObject oldman;
    int chatInt;
    bool spaceAble;
    // Use this for initialization
    void Start () {
        StartCoroutine(StartWaitTimer(3, "WaitOnStart"));
    }
	
	// Update is called once per frame
	void Update () {
        ButtonInput();
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
            case "WaitOnStart":
                LightsOn();
                print("Turned Lights On");
                break;
            case "WaitForText":
                chatBar.SetActive(true);
                textField.GetComponent<TextTyper>().RecieveText(textList[0], "00");
                chatInt++;
                spaceAble = true;
                break;
            case "WaitForCustom":
                oldman.SetActive(false);
                male.SetActive(true);
                maleS.GetComponent<MaleCustomization>().SetOn();
                mainCharCustomizer.SetActive(true);
                characterLights.SetActive(true);
                break;
        }
    }

   public void ChangeGender (int i) {
        switch (i) {
            case 0:
                female.SetActive(false);
                male.SetActive(true);
                maleS.GetComponent<MaleCustomization>().SetOn();
                femaleS.GetComponent<MaleCustomization>().SetOff();
                break;
            case 1:
                maleS.GetComponent<MaleCustomization>().SetOff();
                femaleS.GetComponent<MaleCustomization>().SetOn();
                male.SetActive(false);
                female.SetActive(true);
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

    void ChatBarButton (int i) {
        switch (i) {
            case 1:
                textField.GetComponent<TextTyper>().RecieveText(textList[chatInt], "0" + chatInt.ToString());
                //   spaceAble = false;
                chatInt++;
                break;
            case 2:
                chatBar.SetActive(false);
                LightsOff();
                StartCoroutine(StartWaitTimer(2, "WaitForCustom"));
                break;
        }
    }
}
