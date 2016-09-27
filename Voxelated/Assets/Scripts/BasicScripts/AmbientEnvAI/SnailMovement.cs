using UnityEngine;
using System.Collections;
using System;

public class SnailMovement : MonoBehaviour {
	public EnvAI snail;
	//public EnvAI frog;
	public float waitForSlow;
	public float waitForFast;
	public float speedInc;
	public bool fast;
	public float scale;


	// Use this for initialization
	void Start () {
		snail = new EnvAI(-1, 0, false);
		//frog = new EnvAI(20, 0, false, 0);
		StartCoroutine(SnailNat());
	}
	
	// Update is called once per frame
	void Update () {
		 SnailMoving ();
		 if(fast == true){
		 	if(transform.localScale.z > 2){
		 		return;
		 	}	
		 	Vector3 scaler = transform.localScale;
		 	scaler.z += scale;
		 	transform.localScale = scaler;
		 }
		 else{
		 	if(transform.localScale.z < 0.8){
		 		return;
		 	}	
		 	print("small pls");
		 	Vector3 scaler = transform.localScale;
		 	scaler.z -= scale;
		 	transform.localScale = scaler;
		 }
	}

	[Serializable]
	public class EnvAI {
		public float speed;
		public int scareZone;
		public bool scared = false;

		public EnvAI(float _speed, int _scareZone, bool _scared){
			speed = _speed;
			scareZone = _scareZone;
			scared = _scared;
		}
	}
	void SnailMoving () {
		transform.Translate(transform.forward * snail.speed * Time.deltaTime);
	}

	IEnumerator SnailNat(){
		snail.speed -= speedInc;
		fast = true;
		yield return new WaitForSeconds(waitForSlow);
		snail.speed += speedInc;
		fast = false;
		yield return new WaitForSeconds(waitForFast);
		StartCoroutine(SnailNat());
	}

}
