using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour {

    public GameObject player;
    public GameObject interactTrigger;

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
                SceneManager.LoadScene(8);
                break;
        }
    }
}