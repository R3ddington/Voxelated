using UnityEngine;
using System.Collections;

public class EmergencyLight : MonoBehaviour {

    public GameObject eLight;
    public bool onOff;

	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("L"))
        {
            if (onOff)
            {
                onOff = false;
                eLight.SetActive(false);
            }
            else
            {
                onOff = true;
                eLight.SetActive(true);
            }
        }
	}
}