using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour
{
    // Start is called before the first frame update
    public ParticleSystem particle;
    void Start()
    {
        GlobalPath.ondestroyparticle = particle;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
