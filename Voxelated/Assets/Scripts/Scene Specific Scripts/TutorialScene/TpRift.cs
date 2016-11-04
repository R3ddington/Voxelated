using UnityEngine;
using System.Collections;

public class TpRift : MonoBehaviour
{
    public Transform loc;
    public Animator fade;
    public int step;
    bool locked;
    bool spaceable;
    public GameObject chat;

    void Update ()
    {
        if (spaceable)
        {
            if (Input.GetButtonDown("Jump"))
            {
                ChatSkip();
            }
        }
    }

    void OnTriggerEnter(Collider c)
    {
        if (c.transform.tag == "Player")
        {
            if (!locked)
            {
                locked = true;
                fade.SetTrigger("FadeOut");
                c.transform.GetComponent<CharacterScript>().Freeze();
                c.transform.GetComponent<CharacterScript>().HitFreezeOn();
                StartCoroutine(Wait(c.gameObject));
            }
        }
    }
    IEnumerator Wait (GameObject g)
    {
        yield return new WaitForSeconds(1);
        g.transform.position = loc.position;
        g.transform.rotation = loc.rotation;
        yield return new WaitForSeconds(3);
        fade.SetTrigger("FadeIn");
        CutScene();
       // Destroy(gameObject);
    }

    void CutScene ()
    {
        switch (step)
        {
            case 0:
                chat.SetActive(true);
                this.GetComponent<TextTyper>().RecieveText("Its time", "TPRift_0");
                break;
            case 1:
                this.GetComponent<TextTyper>().RecieveText("I will keep the rift open until you are back", "TPRift_1");
                break;
            case 2:
                this.GetComponent<TextTyper>().RecieveText("Goodluck and stay safe", "TPRift_0");
                break;
            case 3:
                chat.SetActive(false);
                break;
        }
    }
    public void ChatReady()
    {
        {
            spaceable = true;
        }
    }

    public void ChatSkip()
    {
        spaceable = false;
        step++;
        CutScene();
    }
}