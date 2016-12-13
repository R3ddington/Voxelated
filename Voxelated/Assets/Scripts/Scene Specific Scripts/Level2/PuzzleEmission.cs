using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleEmission : MonoBehaviour
{

    public Renderer rend;
    public Material mat;
    public float useFloat;
    public int counter;
    public bool increasing;
    public int intensity;

    // Use this for initialization
    void Start()
    {
        rend = GetComponentInChildren<Renderer>();
        mat = rend.material;
    }

    public void LightUp()
    {
        counter = intensity;
        increasing = true;
        StartCoroutine(RunNumber());
    }
    public void LightOff()
    {
        counter = intensity;
        increasing = false;
        StartCoroutine(RunNumber());
    }

    public void SetColor()
    {
        Color baseColor = Color.white;
        Color finalColor = baseColor * Mathf.LinearToGammaSpace(useFloat);
        mat.SetColor("_EmissionColor", finalColor);
        if(counter > 0)
        {
            StartCoroutine(RunNumber());
        }
        else
        {
            if (!increasing)
            {
                useFloat = 0;
            }
            else
            {
                useFloat = 2;
            }
        }
    }

    IEnumerator RunNumber()
    {
        yield return new WaitForSeconds(0.1f);
        if (increasing)
        {
            if(useFloat < 2)
            {
                useFloat += 0.1f;
            }
            counter--;
        }
        else
        {
            useFloat -= 0.3f;
            counter -= 3;
        }
        SetColor();
    }
}
