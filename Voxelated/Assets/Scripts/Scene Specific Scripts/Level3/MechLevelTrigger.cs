using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MechLevelTrigger : MonoBehaviour {
    public Animator fade;
    public bool activated;
    void OnTriggerEnter(Collider c)
    {
        if(c.transform.tag == "Player")
        {
            if (activated)
            {
                return;
            }
            activated = true;
            fade.SetTrigger("FadeOut");
            StartCoroutine(WaitForLoad());
        }
    }
    IEnumerator WaitForLoad()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(11);
    }
}
