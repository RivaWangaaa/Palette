using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class FlowchartVariablesManager : MonoBehaviour
{
    public static FlowchartVariablesManager instance;

    public Flowchart variableManager;

    private void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
    
    
}
