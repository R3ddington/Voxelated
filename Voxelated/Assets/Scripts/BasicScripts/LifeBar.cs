using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class LifeBar : MonoBehaviour
{
    public Image hpBar;

    public void Damage(int life, int damage)
    {
        float hp;
        hp = 1;
        hp = hp/ life * damage;
        hpBar.fillAmount -= hp;
    }
}
