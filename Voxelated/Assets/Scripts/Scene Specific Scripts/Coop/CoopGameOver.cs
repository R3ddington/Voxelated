using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CoopGameOver : MonoBehaviour {

	public void BackToMenu ()
    {
        SceneManager.LoadScene(0);
    }
    public void Restart ()
    {
        SceneManager.LoadScene(2);
    }
}
