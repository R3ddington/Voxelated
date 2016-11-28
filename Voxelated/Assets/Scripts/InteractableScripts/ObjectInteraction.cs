using UnityEngine;
using System.Collections;

public class ObjectInteraction : MonoBehaviour {
    public GameObject target;
    public GameObject interactText;
    public bool activated;
    public bool locked;

    public int type;

    void Update ()
    {
        if (activated)
        {
            WaitForInput();
        }
    }

    void OnTriggerEnter(Collider c)
    {
        if(c.transform.tag == "Player")
        {
            interactText.SetActive(true);
            activated = true;
        }
    }
    void OnTriggerExit(Collider c)
    {
        if (c.transform.tag == "Player")
        {
            interactText.SetActive(false);
            activated = false;
        }
    }
    public void WaitForInput()
    {
        if (Input.GetButtonDown("E"))
        {
            if (!locked)
            {
                switch (type)
                {
                    case 0:
                        target.GetComponent<OpenChest>().Interact();
                        interactText.SetActive(false);
                        Destroy(gameObject);
                        break;
                    case 1:
                        target.GetComponent<BossDoor>().CheckDoor();
                        interactText.SetActive(false);
                        break;
                    case 2:
                        locked = true;
                        interactText.SetActive(false);
                        target.SetActive(true);
                        target.GetComponent<LevelSelect>().FreezePlayer();
                        break;
                    case 3:
                        locked = true;
                        interactText.SetActive(false);
                        target.SetActive(true);
                        target.GetComponent<ShopScript>().FreezePlayer();
                        break;
                }
            }
        }
    }
}