using UnityEngine;
using System.Collections;

public class CoopDataHolder : MonoBehaviour {
    public GameObject[] turrets;
    public GameObject waveSystem;

    public void GetRequest(int id, GameObject g)
    {
        switch (id)
        {
            case 0:
                g.GetComponent<Strypu>().GainInfo(turrets[1],turrets[2], turrets[0]);
                break;
            case 1:
                g.GetComponent<Strypu>().GainInfo(turrets[3], turrets[4], turrets[0]);
                break;
            case 2:
                g.GetComponent<Strypu>().GainInfo(turrets[5], turrets[6], turrets[0]);
                break;
            case 3:
                g.GetComponent<Strypu>().GainInfo(turrets[7], turrets[8], turrets[0]);
                break;
            case 4:
                g.GetComponent<Guardian>().GainInfo(turrets[1], turrets[2], turrets[0]);
                break;
            case 5:
                g.GetComponent<Guardian>().GainInfo(turrets[3], turrets[4], turrets[0]);
                break;
            case 6:
                g.GetComponent<Guardian>().GainInfo(turrets[5], turrets[6], turrets[0]);
                break;
            case 7:
                g.GetComponent<Guardian>().GainInfo(turrets[7], turrets[8], turrets[0]);
                break;
        }
    }

    public void SendQubits(int i)
    {
        waveSystem.GetComponent<CoopWaveSystem>().AddQubits(i);
    }
}
