using UnityEngine;
using System.Collections;

public class CharacterScript : MonoBehaviour {
    public int health;
    public Animator anim;
    public bool freeze;
    public float speed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Moving();
        OnButtonDown();
	}
    
    //Character Walking
    void Moving () {
        if (!freeze) {
            transform.Translate(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * speed * Time.deltaTime);
        }
    }
    //Button Input
    void OnButtonDown() {
        if (Input.GetButtonDown("Jump")) {
            if (!freeze) {
                Jump();
            }
        }
    }
    void Jump () {
        //Do jumping
    }
}
