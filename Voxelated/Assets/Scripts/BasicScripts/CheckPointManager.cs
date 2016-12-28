using UnityEngine;
using System.Collections;

public class CheckPointManager : MonoBehaviour {

    public GameObject checkpoint;
    public int qubits;
    public string special;
	
    public void SetPoint(GameObject g, int i, string s)
    {
        checkpoint = g;
        qubits = i;
        special = s;
    }
    public void GoToPoint(GameObject g)
    {
        if(checkpoint != null)
        {
            g.transform.position = checkpoint.transform.position;
        }
        else
        {
            g.transform.position = new Vector3(0, 0, 0);
        }
    }
}
