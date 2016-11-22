using UnityEngine;
using System.Collections;

public class FloatingTree : MonoBehaviour {

    void OnCollisionEnter(Collision c)
    {
        if(c.transform.tag == "Player")
        {
            c.transform.GetComponent<CharacterScript>().OnLog();
        }
    }
    void OnCollisionExit(Collision c)
    {
        if (c.transform.tag == "Player")
        {
            c.transform.GetComponent<CharacterScript>().OffLog();
        }
    }
}