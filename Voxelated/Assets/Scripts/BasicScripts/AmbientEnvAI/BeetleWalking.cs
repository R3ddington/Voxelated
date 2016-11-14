using UnityEngine;
using System.Collections;

public class BeetleWalking : MonoBehaviour {

    public Animator anim;
    public float BeetleSpeed;

	// Update is called once per frame
	void Update () {
        walkingBeetle();
	}

    void walkingBeetle() {
        anim.SetBool("Walking", true);
        transform.Translate(transform.forward * BeetleSpeed * Time.deltaTime);
    }
}
