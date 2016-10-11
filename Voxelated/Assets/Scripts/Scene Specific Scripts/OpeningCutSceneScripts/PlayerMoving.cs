using UnityEngine;
using System.Collections;

public class PlayerMoving : MonoBehaviour {
    NavMeshAgent nav;
    public void Move(Vector3 target)
    {
        if (nav == null)
        {
            nav = GetComponent<NavMeshAgent>();
        }
        nav.SetDestination(target);
    }
}
