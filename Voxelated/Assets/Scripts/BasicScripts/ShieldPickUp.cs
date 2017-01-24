using UnityEngine;
using System.Collections;

public class ShieldPickUp : MonoBehaviour {
    public int shield;
    public int type;
    public GameObject hud;
    void OnTriggerEnter(Collider c)
    {
        if (c.transform.tag == "Player")
        {
            c.transform.GetComponent<CharacterScript>().HpShieldPickupSound();
            switch (type)
            {
                case 0:
                    c.transform.gameObject.GetComponent<CoopPlayerController>().AddShield(shield);
                    break;
                case 1:
                    if (hud == null)
                    {
                        hud = GameObject.FindGameObjectWithTag("Hud");
                    }
                    hud.GetComponent<PlayerHUD>().AddShield(shield /*c.gameObject*/);
                    break;
            }
            Destroy(gameObject);
        }
    }
}