using UnityEngine;
using System.Collections;

public class MainHubScript : MonoBehaviour {
    public GameObject cam;
    public GameObject[] adults;
	// Use this for initialization
	void Start () {
        //   cam.GetComponent<CameraFollowScript>().SetActive();
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if(player != null)
        {
            cam.GetComponent<CameraFollowScript>().SetPlayer(player);
            cam.GetComponent<CameraFollowScript>().SetActive();
        }
        else
        {
            print("PLAYER NOT FOUND!");
        }
    }
	
    /*
	// Update is called once per frame
	void Update () {
	
	}
    */
}
