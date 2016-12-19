using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelRotation : MonoBehaviour {

    //Dit script moet op IceySolarPanels-A

    float rotateCount;
    float rotateCountUp = 3;

	// Update is called once per frame
	void Update () {
        panelRotation();
	}

    public void panelRotation() {
        if (rotateCount <= 15) {
            transform.Rotate(transform.right * 3 * Time.deltaTime);
            rotateCount += rotateCountUp * Time.deltaTime;
            print(rotateCount);
        }
        else if (rotateCount >= 15) {
            transform.Rotate(-transform.right * 3 * Time.deltaTime);
            rotateCount += rotateCountUp * Time.deltaTime;
            print(rotateCount + "Above 15");
            if (rotateCount >= 45) {
                rotateCount = -15;
            }
        }
    }
}
