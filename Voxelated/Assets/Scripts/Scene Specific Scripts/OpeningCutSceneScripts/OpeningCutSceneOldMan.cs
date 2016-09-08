using UnityEngine;
using System.Collections;

public class OpeningCutSceneOldMan : MonoBehaviour {
    public Animator spotlights;
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

                break;
        }
    }

    void LightsOn () {
        spotlights.SetTrigger("On");
        StartCoroutine(StartWaitTimer(2, "WaitForText"));
    }
}
