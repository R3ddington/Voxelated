using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaParticles : MonoBehaviour {
    public int maxRate;
    public float[] bursts;
    // Use this for initialization
    void Start()
    {
        ParticleSystem ps = GetComponent<ParticleSystem>();
        var em = ps.emission;
        em.enabled = true;

        em.SetBursts(
            new ParticleSystem.Burst[]{
                new ParticleSystem.Burst(bursts[0], 100),
                new ParticleSystem.Burst(bursts[1], 100),
                new ParticleSystem.Burst(bursts[2], 100)
            });
    }
}
