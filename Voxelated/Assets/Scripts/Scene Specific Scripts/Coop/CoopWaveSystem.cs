using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CoopWaveSystem : MonoBehaviour {
    int wave;
    public GameObject[] spawnPoints;
    public GameObject[] enemies; //0 = Strypu 
    public Text waveCount;
    int qubits;
    public Text qubitCount;
    public GameObject pickup;
    // Use this for initialization
    void Start() {
        Waves(0);
    }

    /*
	// Update is called once per frame
	void Update () {
	
	}
    */

    void Waves(int i)
    {
        switch (i)
        {
            case 0:
                StartCoroutine(WaveTimer(5));
                break;
            case 1:
                //Start wave 1
                PrepareStrypu(1, 0);
                StartCoroutine(WaveTimer(15));
                break;
            case 2:
                PrepareStrypu(2, 1);
                PrepareGuardian(1, 0);
                StartCoroutine(WaveTimer(15));
                break;
            case 3:
                PrepareStrypu(2, 1);
                PrepareGuardian(1, 1);
                StartCoroutine(WaveTimer(20));
                break;
            case 4:
                PrepareStrypu(3, 0);
                PrepareGuardian(2, 2);
                StartCoroutine(WaveTimer(40));
                break;
            case 5:
                pickup.GetComponent<PickUpMaster>().Health();
                pickup.GetComponent<PickUpMaster>().Shield();
                pickup.GetComponent<PickUpMaster>().Qubit();
                PrepareStrypu(2, 0);
                StartCoroutine(WaveTimer(40));
                break;
        }
    }

    void PrepareStrypu(int amount, int id)
    {
        switch (id)
        {
            case 0:
                SummonStrypu(0);
                SummonStrypu(1);
                amount--;
                if (amount > 0)
                {
                    StartCoroutine(SpawnDelay(0, amount, id));
                }
                break;
            case 1:
                SummonStrypu(2);
                SummonStrypu(3);
                amount--;
                if (amount > 0)
                {
                    StartCoroutine(SpawnDelay(0, amount, id));
                }
                break;
            case 2:

                break;
        }
    }

    void PrepareGuardian(int amount, int id)
    {
        switch (id)
        {
            case 0:
                SummonGuardian(4);
                SummonGuardian(5);
                amount--;
                if (amount > 0)
                {
                    StartCoroutine(SpawnDelay(1, amount, id));
                }
                break;
            case 1:
                SummonGuardian(6);
                SummonGuardian(7);
                amount--;
                if (amount > 0)
                {
                    StartCoroutine(SpawnDelay(1, amount, id));
                }
                break;
            case 2:
                SummonGuardian(4);
                SummonGuardian(5);
                SummonGuardian(6);
                SummonGuardian(7);
                amount--;
                if (amount > 0)
                {
                    StartCoroutine(SpawnDelay(1, amount, id));
                }
                break;
        }
    }

    void SummonStrypu(int loc)
    {
        GameObject strypu = Instantiate(enemies[0], spawnPoints[loc].transform.position, Quaternion.identity) as GameObject;
        strypu.GetComponent<Strypu>().SetLane(loc);
    }

    void SummonGuardian(int loc)
    {
        int spawnLoc = loc - 4;
        GameObject guardian = Instantiate(enemies[1], spawnPoints[spawnLoc].transform.position, Quaternion.identity) as GameObject;
        guardian.GetComponent<Guardian>().SetLane(loc);
    }

    IEnumerator SpawnDelay(int i, int amount, int id)
    {
        yield return new WaitForSeconds(0.5f);
        switch (i)
        {
            case 0:
                PrepareStrypu(amount, id);
                break;
            case 1:
                PrepareGuardian(amount, id);
                break;
        }
    }

    IEnumerator WaveTimer(int i)
    {
        yield return new WaitForSeconds(i);
        wave++;
        waveCount.text = wave.ToString();
        Waves(wave);
    }

    public void AddQubits(int i)
    {
        qubits += i;
        qubitCount.text = qubits.ToString();
    }
}
