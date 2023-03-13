using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreePartScript : MonoBehaviour
{
    public ParticleSystem woodDebris;
    // Start is called before the first frame update
    void Start()
    {
        woodDebris.Play();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
