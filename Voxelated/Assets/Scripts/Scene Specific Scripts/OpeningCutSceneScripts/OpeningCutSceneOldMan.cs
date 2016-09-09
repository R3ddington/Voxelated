using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class OpeningCutSceneOldMan : MonoBehaviour {
    public Animator spotlights;
    public List<string> textList = new List<string>();
    public GameObject textField;
    public GameObject chatBar;
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
        }
    }

    void LightsOn () {
        spotlights.SetTrigger("On");
        StartCoroutine(StartWaitTimer(2, "WaitForText"));
    }

    void ChatBarButton (int i) {
        switch (i) {
            case 1:
                textField.GetComponent<TextTyper>().RecieveText(textList[chatInt], "0" + chatInt.ToString());
                spaceAble = false;
                break;
            case 2:

                break;
        }
    }
}
