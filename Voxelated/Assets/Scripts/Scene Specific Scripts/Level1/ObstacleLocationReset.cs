using UnityEngine;
using System.Collections;

public class ObstacleLocationReset : MonoBehaviour {
    public float damage;
    void OnTriggerEnter(Collider c)
    {
        if (c.transform.tag == "Player")
        {
            GameObject tempCheck = GameObject.FindGameObjectWithTag("CheckpointMaster");
            Vector3 checkpoint = tempCheck.GetComponent<CheckPointManager>().checkpoint.transform.position;
            c.transform.position = checkpoint;
            c.GetComponent<CharacterScript>().TakeDamage(damage, true);
        }
    }
}
