using UnityEngine;
using System.Collections;

public class TpRift : MonoBehaviour
{
    public Transform loc;
    void OnTriggerEnter(Collider c)
    {
        if (c.transform.tag == "Player")
        {
            c.transform.position = loc.position;
            Destroy(gameObject);
        }
    }
}