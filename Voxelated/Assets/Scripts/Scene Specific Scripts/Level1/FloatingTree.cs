using UnityEngine;
using System.Collections;

public class FloatingTree : MonoBehaviour {

    /*
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    */

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
