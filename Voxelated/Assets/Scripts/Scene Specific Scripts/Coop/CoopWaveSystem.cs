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
                PrepareStrypu(2, 0);
                StartCoroutine(WaveTimer(15));
                break;
            case 2:
                PrepareStrypu(2, 1);
                StartCoroutine(WaveTimer(15));
                break;
            case 3:
                PrepareStrypu(3, 1);
                StartCoroutine(WaveTimer(20));
                break;
            case 4:
                PrepareStrypu(4, 1);
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
        }
    }

    void SummonStrypu(int loc)
    {
        GameObject strypu = Instantiate(enemies[0], spawnPoints[loc].transform.position, Quaternion.identity) as GameObject;
        strypu.GetComponent<Strypu>().SetLane(loc);
    }

    IEnumerator SpawnDelay(int i, int amount, int id)
    {
        yield return new WaitForSeconds(0.5f);
        switch (i)
        {
            case 0:
                PrepareStrypu(amount, id);
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
