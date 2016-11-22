using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ChatColor : MonoBehaviour {

    public Text baseLine; //To save as backup
    public Text handleLine; //To do stuff with
    public Text showLine; //To show to the player
    public int type;
    int wholeLineInt;
  //  public string color1;
   // public string color2;

	// Use this for initialization
	void Start () {
        baseLine.text = showLine.text;
        handleLine = baseLine;
        switch (type)
        {
            case 0:
                ChangeWholeLine();
                break;
        }
	}
	
    void ChangeWholeLine ()
    {
        switch (wholeLineInt)
        {
            case 0:
                handleLine.color = Color.white;
                wholeLineInt = 1;
                break;
            case 1:
                handleLine.color = Color.yellow;
                wholeLineInt = 0;
                break;
        }
        showLine = handleLine;
        StartCoroutine(WholeLineWait());
    }

    IEnumerator WholeLineWait()
    {
        yield return new WaitForSeconds(1);
        ChangeWholeLine();
    }
}