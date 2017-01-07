using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcadeBossTrigger : MonoBehaviour {
    public GameObject miniGame;
    public Animator fade;
    void OnTriggerEnter(Collider c)
    {
        if(c.transform.tag == "Player")
        {
            c.transform.GetComponent<CharacterScript>().FreezeOn();
            fade.SetTrigger("FadeOut");
            StartCoroutine(WaitTillGame());
        }
    }

    IEnumerator WaitTillGame ()
    {
        yield return new WaitForSeconds(3);
        miniGame.SetActive(true);
        Destroy(gameObject);
    }
}
