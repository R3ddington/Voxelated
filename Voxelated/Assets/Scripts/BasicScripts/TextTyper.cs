using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class TextTyper : MonoBehaviour {
    //public List<string> textList = new List<string>();
    string handleString;
    public Text textField;
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
            ShowText(s);
            busy = true;
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
            StartCoroutine(ChatDelay(s));
        }
        else {
            busy = false;
        }
    }
    IEnumerator ChatDelay (string s) {
        yield return new WaitForSeconds(0.2f);
        ShowText(s);
    }
}