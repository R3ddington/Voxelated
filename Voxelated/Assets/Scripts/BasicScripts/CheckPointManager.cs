using UnityEngine;
using System.Collections;

public class CheckPointManager : MonoBehaviour {

    public GameObject checkpoint;
    public int qubits;
	
    public void SetPoint(GameObject g, int i)
    {
        checkpoint = g;
        qubits = i;
    }
    public void GoToPoint(GameObject g)
    {
        g.transform.position = checkpoint.transform.position;
    }
}
