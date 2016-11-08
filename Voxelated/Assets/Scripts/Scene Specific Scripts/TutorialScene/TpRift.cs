using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TpRift : MonoBehaviour
{
    public Transform loc;
    public Animator fade;
    public int step;
    bool locked;
    bool spaceable;
    public GameObject chat;
    public GameObject player;
    bool movePlayer;

    void Update ()
    {
        if (spaceable)
        {
            if (Input.GetButtonDown("Jump"))
            {
                ChatSkip();
            }
        }
        if (movePlayer)
        {
            MovePlayer();
        }
    }

    void OnTriggerEnter(Collider c)
    {
        if (c.transform.tag == "Player")
        {
            if (!locked)
            {
                player = c.gameObject;
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
                player.GetComponent<CharacterScript>().SpecialLock(1);
                break;
            case 1:
                this.GetComponent<TextTyper>().RecieveText("I will keep the rift open until you are back", "TPRift_1");
                break;
            case 2:
                this.GetComponent<TextTyper>().RecieveText("Goodluck and stay safe", "TPRift_0");
                break;
            case 3:
                chat.SetActive(false);
                step = 4;
                CutScene();
                break;
            case 4:
                player.GetComponentInChildren<Animator>().SetBool("Walk", true);
                movePlayer = true;
                StartCoroutine(Wait(2));
                break;
            case 5:
                fade.SetTrigger("FadeOut");
                StartCoroutine(Wait(5));
                break;
            case 6:
                player.GetComponent<CharacterScript>().SpecialLock(0);
                // Animator anim = player.GetComponentInChildren<Animator>();
                //  anim.SetBool("Walk", false);
                player.GetComponentInChildren<Animator>().SetBool("Walk", false);
                SceneManager.LoadScene(7);
                break;
        }
    }
    void MovePlayer ()
    {
        player.transform.Translate(new Vector3(0, 0, 1) * 20 * Time.deltaTime);
    }
    public void ChatReady()
    {
        if (!(step >= 4))
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
    IEnumerator Wait(int waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        step++;
        CutScene();
    }
}