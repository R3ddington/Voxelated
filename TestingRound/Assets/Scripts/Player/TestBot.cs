using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBot : MonoBehaviour {

    public float movementSpeed;
    public float moveCounter;
    float moveCounterUp = 4;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        TestBotter();
	}

    public void TestBotter() {
        if (moveCounter <= 15) {
            transform.Translate(transform.right * movementSpeed * Time.deltaTime);
            moveCounter += moveCounterUp * Time.deltaTime;
            print(moveCounter);
        }
        else if(moveCounter >= 15) {
            transform.Translate(-transform.right * movementSpeed * Time.deltaTime);
            moveCounter += moveCounterUp * Time.deltaTime;
            print(moveCounter + "Above 15");
            if(moveCounter >= 45) {
                moveCounter = -15;
            }
            print("It's over 15!");
        }
    }
}
