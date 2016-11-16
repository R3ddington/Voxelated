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

    public GameObject gameOver;

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

    public void HPShieldReduct(float d, bool trueDamage) {
        float damage = d / 100;
        if (shieldBar.fillAmount > 0 && !trueDamage)
        {
            shieldBar.fillAmount -= damage;
        }
        else if (shieldBar.fillAmount <= 0 || trueDamage)
        {
            hpBar.fillAmount -= damage;
        }
        if (hpBar.fillAmount <= 0.1) {
            playerDead = true;
            gameOver.SetActive(true);
            headsUD.SetActive(false);
        }
    }
}