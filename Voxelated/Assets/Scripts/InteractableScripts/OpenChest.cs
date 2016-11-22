using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OpenChest : MonoBehaviour {
    public Animator anim;
    public int type;
    public Transform particlePos;
    public GameObject particle;

    public GameObject extraObject;
    public GameObject showLootMessage;
    public Text lootText;

    public int qubits;

	public void Interact ()
    {
        anim.SetTrigger("Open");
        Effect();
    }

    public void Effect ()
    {
        switch (type)
        {
            case 0:
                Instantiate(particle, particlePos.position, Quaternion.identity);
                GameObject player = GameObject.FindGameObjectWithTag("Player");
                player.GetComponent<CharacterScript>().AddQubits(qubits);
                break;
            case 1:
                Instantiate(particle, particlePos.position, Quaternion.identity);
                extraObject.GetComponent<BossDoor>().hasKey = true;
                showLootMessage.SetActive(true);
                lootText.text = "Found  a  key!";
                StartCoroutine(Wait(5));
                break;
        }
    }

    IEnumerator Wait (int i)
    {
        yield return new WaitForSeconds(i);
        showLootMessage.SetActive(false);
    }
}