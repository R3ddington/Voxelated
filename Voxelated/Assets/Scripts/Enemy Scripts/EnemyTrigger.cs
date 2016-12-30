using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrigger : MonoBehaviour {
    public GameObject[] enemies;
    public int type;
    void OnTriggerEnter(Collider c)
    {
        if(c.transform.tag == "Player")
        {
            foreach(GameObject enemy in enemies)
            {
                switch (type)
                {
                    case 0:
                        enemy.GetComponent<Lava_Elemental>().GetPlayer(c.transform.gameObject);
                        break;
                    case 1:
                        enemy.GetComponent<LavaLizard>().GetPlayer(c.transform.gameObject);
                        break;
                }
            }
            Destroy(gameObject);
        }
    }
}
