using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour {

    public GameObject player;
    public GameObject interactTrigger;
    public Animator fade;

    public void FreezePlayer ()
    {
        if(player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
        player.GetComponent<CharacterScript>().freeze = true;
        player.GetComponent<CharacterScript>().hitFreeze = true;
    }

    public void Button (int i)
    {
        switch (i)
        {
            //close level select
            case 0:
                player.GetComponent<CharacterScript>().freeze = false;
                player.GetComponent<CharacterScript>().hitFreeze = false;
                interactTrigger.GetComponent<ObjectInteraction>().locked = false;
                gameObject.SetActive(false);
                break;
            //Load level 1
            case 1:
                player.GetComponent<CharacterScript>().freeze = false;
                player.GetComponent<CharacterScript>().hitFreeze = false;
                StartCoroutine(WaitForLevelLoad());
                break;
        }
    }
    IEnumerator WaitForLevelLoad ()
    {
        yield return new WaitForSeconds(2);
        LoadLevel();
    }
    public void LoadLevel()
    {
        int useThis = player.GetComponent<CharacterScript>().levelNumber;
        switch (useThis)
        {
            case 0:
                SceneManager.LoadScene(8);
                break;
            case 1:
                SceneManager.LoadScene(9);
                break;
        }
    }
}