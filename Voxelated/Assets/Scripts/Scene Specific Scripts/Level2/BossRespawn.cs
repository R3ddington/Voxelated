using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRespawn : MonoBehaviour {
    public GameObject boss;
	public void Respawn ()
    {
        boss.SetActive(true);
    }
}
