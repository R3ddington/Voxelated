using UnityEngine;
using System.Collections;

public class VelReset : MonoBehaviour
{
    void OnTriggerEnter(Collider c)
    {
        if (c.transform.tag == "Player")
        {
            c.transform.GetComponent<CharacterScript>().ResetVelocity();
        }
    }
}
