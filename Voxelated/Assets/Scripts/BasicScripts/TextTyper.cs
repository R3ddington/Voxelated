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
    public GameObject inputObject;
    public int type;

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
            switch(type)
            {
                case 0:
                    this.GetComponent<NewOpeningCutscene>().ChatReady();
                    break;
                case 1:
                    inputObject.GetComponent<TpRift>().ChatReady();
                    break;
                case 2:
                    //Absolutly nothing
                    break;
            }
        }
    }

    public void Switch (int i)
    {
        textField = nextTexts[i];
    }

    public void SetColor (string c)
    {
        switch (c)
        {
            case "red":
                textField.color = Color.red;
                break;
            case "blue":
                textField.color = Color.blue;
                break;
            case "yellow":
                textField.color = Color.yellow;
                break;
            case "pink":
                textField.color = Color.magenta;
                break;
            case "green":
                textField.color = Color.green;
                break;
            case "cyan":
                textField.color = Color.cyan;
                break;
        }
    }

    IEnumerator ChatDelay (string s) {
        yield return new WaitForSeconds(0.04f);
        ShowText(s);
    }
}