﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneReload : MonoBehaviour {

    public int qubits;
    public GameObject tempCheck;
    public Vector3 checkpoint;
    bool prepared;

    void Start ()
    {
        if(!prepared){
            TriggerReload();
        }
    }

	public void TriggerReload ()
    {
        print("reload triggered");
        DontDestroyOnLoad(gameObject);
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        tempCheck = GameObject.FindGameObjectWithTag("CheckpointMaster");
        checkpoint = tempCheck.GetComponent<CheckPointManager>().checkpoint.transform.position;
        qubits = tempCheck.GetComponent<CheckPointManager>().qubits;
        prepared = true;
        player.GetComponent<CharacterScript>().reloaded = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void DoLoad()
    {
        print("Reloading");
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if(player == null)
        {
            print("Player not found in DoLoad void, starting retry counter");
            StartCoroutine(WaitForRetry());
            return;
        }
        print("Found player, pushing reload");
        player.GetComponent<CharacterScript>().qubits = qubits;
        player.GetComponent<CharacterScript>().SetUp();
        player.transform.position = checkpoint;
       // player.GetComponent<CharacterScript>().checkpointPos = checkpoint;
        player.GetComponent<CharacterScript>().freeze = false;
        Time.timeScale = 1f;
        Destroy(gameObject);
    }
    IEnumerator WaitForRetry()
    {
        yield return new WaitForSeconds(2);
        print("Retrying reload");
        DoLoad();
    }
}
