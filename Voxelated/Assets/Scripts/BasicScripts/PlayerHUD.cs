using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class PlayerHUD : MonoBehaviour {
    public Image hpBar;
    public float fillReductHP;
    public GameObject headsUD;
    public Image shieldBar;
    public float fillReductShield;
    public bool playerDead;
    public Image ammoFillBar;
    public int ammoReduct;
   // public GameObject ammoHUD;
    public GameObject gunIcons;
    public GameObject swordIcon;
    bool gunEquiped;
    public Text qubitsCounter;

    public GameObject gameOver;
    public GameObject parentObject;

    void Start ()
    {
        DontDestroyOnLoad(parentObject);
    }

    public void WeaponSwitching(int i) {
        switch (i)
        {
            case 0:
                gunIcons.SetActive(false);
                swordIcon.SetActive(true);
                gunEquiped = false;
                break;
            case 1:
                gunIcons.SetActive(true);
                swordIcon.SetActive(false);
                gunEquiped = true;
                break;
        }
    }

    public void AmmoAndGunReduct(float a) {
        if (ammoFillBar.fillAmount >= 0)
        {
            float ammo = a / ammoReduct;
            ammoFillBar.fillAmount -= ammo;
        }
    }

    public void AddAmmo ()
    {
        //Instant refill for now, change to show bar filling later
        ammoFillBar.fillAmount = 1;
    }

    public void SetQubits (int i)
    {
        qubitsCounter.text = i.ToString();
    }

    public void AddShield (float i, GameObject p)
    {
        float regen = i / 100;
        shieldBar.fillAmount += regen;
        p.GetComponent<CharacterScript>().shield = shieldBar.fillAmount * 100;
    }

    public void AddHP(int i)
    {
        float regen = i / 100;
        hpBar.fillAmount = regen;
    }

    public void HPShieldReduct(float d, bool trueDamage, GameObject p) {
        float damage = d / 100;
        if (shieldBar.fillAmount > 0 && !trueDamage)
        {
            shieldBar.fillAmount -= damage;
            p.GetComponent<CharacterScript>().shield = shieldBar.fillAmount * 100;
        }
        else if (shieldBar.fillAmount <= 0 || trueDamage)
        {
            hpBar.fillAmount -= damage;
        }
        if (hpBar.fillAmount <= 0.1) {
            playerDead = true;
            if(gameOver != null)
            {
                gameOver.SetActive(true);
                Time.timeScale = 0f;
            }
            headsUD.SetActive(false);
        }
    }
}