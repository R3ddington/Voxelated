using UnityEngine;
using System.Collections;

public class MainMenuButtons : MonoBehaviour {
    public GameObject[] screens; //0 = mainscreen, 1 = options screen
    /*
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    */
   public void Button (int i) {
        switch (i) {
            case 0:
                screens[0].SetActive(false);
                screens[1].SetActive(true);
                break;
            case 1:
                screens[0].SetActive(true);
                screens[1].SetActive(false);
                break;
        }
    }
}
