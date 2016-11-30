using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeEmission : MonoBehaviour {

    public Renderer rend;
    public Material mat;

    // Use this for initialization
    void Start () {
        rend = GetComponent<Renderer>();
        mat = rend.material;
    }
	
	// Update is called once per frame
	void Update () {
        float emission = Mathf.PingPong(Time.time, 5 - 2);
        Color baseColor = Color.white;
        Color finalColor = baseColor * Mathf.LinearToGammaSpace(emission);
        mat.SetColor("_EmissionColor", finalColor);
    }
}
