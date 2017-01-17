using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PresentationMode : MonoBehaviour {
    public bool isPresentation;
    public Vector3[] loc;
    public GameObject player;
    int step;
	// Use this for initialization
	void Start () {
        if (isPresentation)
        {
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this.transform);
        }
	}
	
	// Update is called once per frame
	void Update () {
        ButtonInput();
	}

    public void ButtonInput()
    {
        if (Input.GetButtonDown("9"))
        {
            Skip();
        }
    }
    public void Skip()
    {
        if(player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
        if(player != null)
        {
            player.transform.position = loc[step];
            step++;
        }
    }
}
