using UnityEngine;
using System.Collections;

public class CoopPlayerController : MonoBehaviour {

    public GameObject player;
    public Animator anim;
    public int health;
    public float speed;
    public bool isPlayer1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        ButtonInput();
	}

    void ButtonInput () {
        if (isPlayer1)
        {

        }
        else
        {

        }
    }

}
