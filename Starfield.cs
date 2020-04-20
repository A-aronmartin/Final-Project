﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starfield : MonoBehaviour
{
    public GameController gameController;
    private ParticleSystem ps;
    public float SpeedValue = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        var main = ps.main;
        main.simulationSpeed = SpeedValue;
    }
}
