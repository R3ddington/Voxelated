using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour {
    public GameObject reloadSystem;
	public void BackToMenu ()
    {
        SceneManager.LoadScene(0);
        //save last info
    }

    public void Continue()
    {
        Instantiate(reloadSystem, transform.position, Quaternion.identity);
        //Reload from last checkpoint
        //Pull info
    }
}
