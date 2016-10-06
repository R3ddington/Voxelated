using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour {
    public GameObject[] screens; //0 = mainscreen, 1 = options screen, 2 = Coop menu, 3 = Credits screen
    public Animator fadeAnim;
    public GameObject[] creditText;
    public GameObject[] optionPages; //0 = main page, 1 = audio, 2 = grafics
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
                StartCoroutine(StartWaitTimer(3, 0, 0));
                break;
            case 3:
                screens[0].SetActive(false);
                screens[2].SetActive(true);
                break;
            case 4:
                screens[0].SetActive(true);
                screens[2].SetActive(false);
                break;
            case 5:
                fadeAnim.SetTrigger("Black");
                StartCoroutine(StartWaitTimer(3, 1, 2));
                break;
            case 6:
                screens[0].SetActive(false);
                screens[3].SetActive(true);
                break;
            case 7:
                screens[0].SetActive(true);
                screens[3].SetActive(false);
                break;
        }
    }

    public void CreditButtons (int i)
    {
        for (int o = 0; o < creditText.Length; o++)
        {
            creditText[o].SetActive(false);
        }
        creditText[i].SetActive(true);
    }

    public void OptionsMenu (int i)
    {
        switch (i)
        {
            case 0:
                optionPages[0].SetActive(true);
                optionPages[1].SetActive(false);
                optionPages[2].SetActive(false);
                break;
            case 1:
                optionPages[0].SetActive(false);
                optionPages[1].SetActive(true);
                break;
            case 2:
                optionPages[0].SetActive(false);
                optionPages[2].SetActive(true);
                break;
        }
    }

    IEnumerator StartWaitTimer(int i, int id, int map) {
        yield return new WaitForSeconds(i);
        switch (id)
        {
            case 0:
                StartNewGame();
                break;
            case 1:
                StartCoop(map);
                break;
        }
    }

    void StartNewGame () {
        SceneManager.LoadScene(1);
    }
    void StartCoop (int map)
    {
        SceneManager.LoadScene(map);
    }
}
