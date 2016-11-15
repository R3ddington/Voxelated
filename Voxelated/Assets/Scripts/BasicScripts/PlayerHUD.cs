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
    public float ammoReduct;
    public GameObject ammoHUD;
    public GameObject gunIcons;
    public GameObject swordIcon;
    bool gunEquiped;

    // Use this for initialization
    void Start () {
        gunIcons.SetActive(false);
        swordIcon.SetActive(true);
        gunEquiped = false;
	}
	
	// Update is called once per frame
	void Update () {
        HPShieldReduct();
        WeaponSwitching();
        AmmoAndGunReduct();
    }

    public void WeaponSwitching() {
        if (Input.GetButtonDown("1")) {
            gunIcons.SetActive(false);
            swordIcon.SetActive(true);
            gunEquiped = false;
        }
        else if (Input.GetButtonDown("2")) {
            gunIcons.SetActive(true);
            swordIcon.SetActive(false);
            gunEquiped = true;
        }
    }

    public void AmmoAndGunReduct() {
        if (gunEquiped == true) { 
            if (Input.GetButtonDown("Fire2")) {
                if (ammoFillBar.fillAmount >= 0) {
                    ammoFillBar.fillAmount -= ammoReduct;
                }
            }
        }
    }

    public void HPShieldReduct() {
        if (Input.GetButtonDown("Fire1")) {
            if (shieldBar.fillAmount > 0) {
                shieldBar.fillAmount -= fillReductShield;
            }
            else if (shieldBar.fillAmount <= 0) {
                hpBar.fillAmount -= fillReductHP;
            }
        }
        if (hpBar.fillAmount <= 0.1) {
            playerDead = true;
            headsUD.SetActive(false);
        }

    }


}
