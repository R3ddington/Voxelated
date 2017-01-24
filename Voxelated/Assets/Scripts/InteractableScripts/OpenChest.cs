using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OpenChest : MonoBehaviour {
    public Animator anim;
    public int type;
    public Transform particlePos;
    public GameObject particle;
    public GameObject audioHandler;

    public GameObject extraObject;
    public GameObject showLootMessage;
    public Text lootText;

    public int qubits;

    public void Start() {
        if (audioHandler == null) {
            audioHandler = GameObject.FindGameObjectWithTag("AudioMaster");
        }
    }

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
                if (audioHandler != null) {
                    audioHandler.GetComponent<AudioMaster>().PlayDelay(5, 0.3f);
                }
                break;
            case 1:
                Instantiate(particle, particlePos.position, Quaternion.identity);
                extraObject.GetComponent<BossDoor>().hasKey = true;
                if (audioHandler != null) {
                    audioHandler.GetComponent<AudioMaster>().PlayDelay(5, 1f);
                }
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