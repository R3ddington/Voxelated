using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class TextTyper : MonoBehaviour {
    //public List<string> textList = new List<string>();
    string handleString;
    public Text textField;
    public Text[] nextTexts;
   // public GameObject arrow;
    bool busy;
    public bool isCut;

    public bool isIntro;
    /*
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    */

    public void RecieveText (string s, string id) {
        if (!busy) {
            textField.text = "";
            handleString = "";
            ShowText(s);
            busy = true;
            //arrow.SetActive(false);
        }
        else {
            print("ERROR, received a string while being busy, string id = " + id);
        }
    }

    void ShowText(string s) {
        handleString = handleString + s.Substring(0, 1);
        string l = s.Substring(0, 1);
        textField.text = handleString;
        s = s.Remove(0, 1);
        if (s.Length != 0) {
            if(l == " ")
            {
                handleString = handleString + " ";
            }
            StartCoroutine(ChatDelay(s));
        }
        else {
           // arrow.SetActive(true);
            busy = false;
            if (isIntro)
            {
                this.GetComponent<NewOpeningCutscene>().ChatReady();
            }
        }
    }

    public void Switch (int i)
    {
        textField = nextTexts[i];
    }

    IEnumerator ChatDelay (string s) {
        yield return new WaitForSeconds(0.04f);
        ShowText(s);
    }
}