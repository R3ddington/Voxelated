using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour {
    public GameObject[] screens; //0 = mainscreen, 1 = options screen
    public Animator fadeAnim;
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
            case 2:
                fadeAnim.SetTrigger("Black");
                StartCoroutine(StartWaitTimer(1));
                break;
        }
    }

    IEnumerator StartWaitTimer(int i) {
        yield return new WaitForSeconds(i);
        StartNewGame();
    }

    void StartNewGame () {
        SceneManager.LoadScene(1);
    }
}
