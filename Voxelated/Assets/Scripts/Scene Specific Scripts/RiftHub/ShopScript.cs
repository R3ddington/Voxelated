using UnityEngine;
using System.Collections;

public class ShopScript : MonoBehaviour {

    public int playerQubits;
    public GameObject player;
    public int selectedSword; //0 = katana
    public int selectedGun; //1 = basegun
    public bool[] unlocked; //0 = katana, 1 = basegun, 2 = skullsword
    public int[] price; //0 = katana, 1 = basegun, 2 = skullsword
    public GameObject[] buyButtons; //0 = katana, 1 = basegun, 2 = skullsword
    public GameObject[] useButtons; //0 = katana, 1 = basegun, 2 = skullsword
    public GameObject[] showItems; //0 = katana, 1 = basegun, 2 = skullsword
    public int selectedShowItem;
    public GameObject interactTrigger;

    // Use this for initialization
    void Start () {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
    }

    public void ItemButtons (int i)
    {
        showItems[selectedShowItem].SetActive(false);
        showItems[i].SetActive(true);
        selectedShowItem = i;
    }
	
    public void UseSword (int i)
    {
        selectedSword = player.GetComponent<CharacterScript>().selectedSword;
        if(i != selectedSword)
        {
            int mode = player.GetComponent<CharacterScript>().cMode;
            switch (mode)
            {
                case 0:
                    player.GetComponent<CharacterScript>().handItems[selectedSword].SetActive(false);
                    player.GetComponent<CharacterScript>().handItems[i].SetActive(true);
                    break;
                case 1:
                    player.GetComponent<CharacterScript>().backItems[selectedSword].SetActive(false);
                    player.GetComponent<CharacterScript>().backItems[i].SetActive(true);
                    break;
            }
            player.GetComponent<CharacterScript>().selectedSword = i;
        }
    }

    public void UseGun(int i)
    {
        selectedGun = player.GetComponent<CharacterScript>().selectedGun;
        if (i != selectedGun)
        {
            int mode = player.GetComponent<CharacterScript>().cMode;
            switch (mode)
            {
                case 0:
                    player.GetComponent<CharacterScript>().backItems[selectedGun].SetActive(false);
                    player.GetComponent<CharacterScript>().backItems[selectedGun].SetActive(true);
                    break;
                case 1:
                    player.GetComponent<CharacterScript>().handItems[selectedGun].SetActive(false);
                    player.GetComponent<CharacterScript>().handItems[selectedGun].SetActive(true);
                    break;
            }
            player.GetComponent<CharacterScript>().selectedGun = i;
        }
    }

    public void BuyButtons(int i)
    {
        playerQubits = player.GetComponent<CharacterScript>().qubits;
        if (playerQubits >= price[i])
        {
            playerQubits -= price[i];
            player.GetComponent<CharacterScript>().qubits = playerQubits;
            unlocked[i] = true;
            buyButtons[i].SetActive(false);
            useButtons[i].SetActive(true);
        }
    }

    public void CloseShop()
    {
        player.GetComponent<CharacterScript>().freeze = false;
        player.GetComponent<CharacterScript>().hitFreeze = false;
        interactTrigger.GetComponent<ObjectInteraction>().locked = false;
        gameObject.SetActive(false);
    }
    public void FreezePlayer()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
        player.GetComponent<CharacterScript>().freeze = true;
        player.GetComponent<CharacterScript>().hitFreeze = true;
    }
}