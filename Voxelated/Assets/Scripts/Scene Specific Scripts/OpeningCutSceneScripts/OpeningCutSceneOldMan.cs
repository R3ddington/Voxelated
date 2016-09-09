using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class OpeningCutSceneOldMan : MonoBehaviour {
    public Animator spotlights;
    public List<string> textList = new List<string>();
    public GameObject textField;
    public GameObject chatBar;
    // Use this for initialization
    void Start () {
        StartCoroutine(StartWaitTimer(3, "WaitOnStart"));
    }
	
	// Update is called once per frame
	void Update () {
	
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
                break;
        }
    }

    void LightsOn () {
        spotlights.SetTrigger("On");
        StartCoroutine(StartWaitTimer(2, "WaitForText"));
    }
}
