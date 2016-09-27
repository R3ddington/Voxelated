using UnityEngine;
using System.Collections;
using System;

public class TpEnemy : MonoBehaviour {
	public EnemyMovement warper;
	public GameObject player;
	public Vector3 enemyAdjustPos;
	public float waitForTpBack;
	public GameObject retEnemyPos;
	public bool tpCheck = false;
	public Vector3 retPosAdjustment;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		RaycastDetectingPlayer();
	}

	[Serializable]
	public class EnemyMovement{
		public float range;

		public EnemyMovement(float _range){
			range = _range;
		}
	}
	public void RaycastDetectingPlayer(){
		Vector3 playerPos = player.transform.position;
		bool teleportedEnemy = false ;
		transform.LookAt(player.transform);
		if(Physics.Raycast(transform.position, transform.forward, warper.range)){
			teleportedEnemy = true;
			if(teleportedEnemy = true){
				teleportedEnemy = false;
				transform.position = (playerPos += enemyAdjustPos);
			}
			//tpCheck = true;
			StartCoroutine(TpBackEnemy());
		}
	}

	IEnumerator TpBackEnemy(){
		//if(tpCheck = true){
			yield return new WaitForSeconds(waitForTpBack);
			transform.position = retEnemyPos.transform.position;
			retEnemyPos.transform.position += retPosAdjustment;
			//tpCheck = false;
		//}
	}
}