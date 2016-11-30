using UnityEngine;
using System.Collections;

public class NavMeshTest : MonoBehaviour {

    UnityEngine.AI.NavMeshAgent nav;
    public Transform[] waypoints;
	// Use this for initialization
	void Start () {
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
        nav.SetDestination(waypoints[0].position);
    }
	
	// Update is called once per frame
	void Update () {
        
	}
}
