using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;
    public float speedAdjust;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        PlayerControlHorizontal();
        PlayerControlVertical();
        SlowMotion();
	}

    public void SlowMotion() {
        print("SlowMoActivate");
        if (Input.GetButtonDown("Z")) {
            if (Time.timeScale == 1.0F) {
                Time.timeScale = 0.2F;
                speed = speed * speedAdjust;
            }
            else {
                Time.timeScale = 1.0F;
                speed = 20;
            }
            Time.fixedDeltaTime = 0.02F * Time.timeScale;
            print("MidWay");
        }
        else if (Input.GetButtonDown("X")) {
            if(Time.timeScale == 1.0F) {
                Time.timeScale = 1.8F;
                speed = speed * speedAdjust;
            }
            else {
                Time.timeScale = 1.0F;
                speed = 20;
            }
            Time.fixedDeltaTime = 0.02F * Time.timeScale;
        }
        else if (Input.GetButtonDown("C")) {
            if (Time.timeScale == 1.0F) {
                Time.timeScale = 0;
                speed = speed * speedAdjust;
            }
            else {
                Time.timeScale = 1.0F;
                speed = 20;
            }
            Time.fixedDeltaTime = 0.02F * Time.timeScale;
        }
    }

    public void PlayerControlHorizontal() {
        if (Input.GetAxis("Horizontal") < 0) {
            print("if1Hor");
            transform.Translate(new Vector3(-1, 0, 0) * speed * Time.deltaTime);
        }
        else if(Input.GetAxis("Horizontal") > 0) {
            print("if2Hor");
            transform.Translate(new Vector3(1, 0, 0) * speed * Time.deltaTime);
        }
    }

    public void PlayerControlVertical() {
        if (Input.GetAxis("Vertical") < 0) {
            print("if1Ver");
            transform.Translate(new Vector3(0, 0, -1) * speed * Time.deltaTime);
        }
        else if (Input.GetAxis("Vertical") > 0) {
            print("if2Ver");
            transform.Translate(new Vector3(0, 0, 1) * speed * Time.deltaTime);
        }
    }
}
