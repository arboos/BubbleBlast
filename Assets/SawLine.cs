using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawLine : MonoBehaviour
{
    public static SawLine Instance { get; private set; }

    public LineRenderer line;
    public Transform pos0;
    public Transform pos1;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        line.positionCount = 2;
    }

    private void Update()
    {
        line.SetPosition(0, pos0.position);
        line.SetPosition(1, pos1.position);
    }
}
