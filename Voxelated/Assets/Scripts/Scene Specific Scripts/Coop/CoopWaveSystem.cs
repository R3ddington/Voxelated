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
                StartCoroutine(WaveTimer(20));
                break;
            case 3:
                PrepareStrypu(2, 1);
                PrepareGuardian(1, 1);
                StartCoroutine(WaveTimer(30));
                break;
            case 4:
                PrepareStrypu(3, 0);
                PrepareGuardian(2, 0);
                StartCoroutine(WaveTimer(40));
                break;
            case 5:
                pickup.GetComponent<PickUpMaster>().Health();
                pickup.GetComponent<PickUpMaster>().Shield();
                PrepareStrypu(2, 0);
                StartCoroutine(WaveTimer(40));
                break;
            case 6:
                PrepareGuardian(4, 1);
                pickup.GetComponent<PickUpMaster>().Qubit();
                StartCoroutine(WaveTimer(40));
                break;
            case 7:
                PrepareGuardian(4, 0);
                pickup.GetComponent<PickUpMaster>().Health();
                pickup.GetComponent<PickUpMaster>().Shield();
                StartCoroutine(WaveTimer(40));
                break;
            case 8:
                PrepareGuardian(2, 2);
                StartCoroutine(WaveTimer(40));
                break;
            case 9:
                PrepareStrypu(4, 1);
                StartCoroutine(WaveTimer(60));
                break;
            case 10:
                PrepareStrypu(4, 2);
                pickup.GetComponent<PickUpMaster>().Qubit();
                StartCoroutine(WaveTimer(60));
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