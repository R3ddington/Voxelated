using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcadeShipHealth : MonoBehaviour {

    public int health;
    public bool isPlayer;
    public GameObject player;

    public void TakeDamage (int i)
    {
        health -= i;
        if(health <= 0)
        {
            if (!isPlayer)
            {
                player.GetComponent<PlayerTankController>().AddKill();
                Destroy(gameObject);
            }
            else
            {
                //Do player dead
            }
        }
    }
}
