using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class TextTyper : MonoBehaviour {
    //public List<string> textList = new List<string>();
    string handleString;
    public Text textField;
   // public GameObject arrow;
    bool busy;
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
        textField.text = handleString;
        s = s.Remove(0, 1);
        if (s.Length != 0) {
            if (!(s == " ")) {
                StartCoroutine(ChatDelay(s));
            }
            else {
                ShowText(s);
            }
        }
        else {
           // arrow.SetActive(true);
            busy = false;
        }
    }
    IEnumerator ChatDelay (string s) {
        yield return new WaitForSeconds(0.04f);
        ShowText(s);
    }
}