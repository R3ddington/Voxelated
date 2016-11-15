using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour {

	public void BackToMenu ()
    {
        SceneManager.LoadScene(0);
        //save last info
    }

    public void Continue()
    {
        //Reload from last checkpoint
        //Pull info
    }
}
