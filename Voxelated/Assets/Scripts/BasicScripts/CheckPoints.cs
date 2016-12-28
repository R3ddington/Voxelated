using UnityEngine;
using System.Collections;

public class CheckPoints : MonoBehaviour {
    public GameObject checkpointMaster;
    public string specialCode;
    public string specialChecks;
    void OnTriggerEnter(Collider c)
    {
        if(c.transform.tag == "Player")
        {
            int i = c.transform.GetComponent<CharacterScript>().qubits;
            print("Sending qubits" + i.ToString());
            if(specialChecks != null)
            {
                switch (specialChecks)
                {
                    case "checkKey":
                        GameObject bD = GameObject.FindGameObjectWithTag("Level1Door");
                        if(bD.GetComponent<BossDoor>().hasKey == true)
                        {
                            specialCode = "hasKey";
                        }
                        break;
                }
            }
            checkpointMaster.GetComponent<CheckPointManager>().SetPoint(gameObject, i, specialCode);
        }
    }
}
