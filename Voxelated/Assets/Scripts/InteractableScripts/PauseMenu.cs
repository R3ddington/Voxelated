using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {
    public GameObject reloadSystem;

	public void Continue ()
    {
        Time.timeScale = 1f;
        this.gameObject.SetActive(false);
    }
    public void Checkpoint ()
    {
        Instantiate(reloadSystem, transform.position, Quaternion.identity);
        this.gameObject.SetActive(false);
    }
    public void BackToMenu ()
    {
        SceneManager.LoadScene(0);
    }
}
