using UnityEngine;
using System.Collections;

public class BabyScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(transform.gameObject);
    }
}
