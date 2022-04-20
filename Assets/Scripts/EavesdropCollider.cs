using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EavesdropCollider : MonoBehaviour
{
    [SerializeField] private GameObject noCloseFungus;
    private bool isFungusAlreadyTriggered;
    
    public void TriggerNoCloseFungus()
    {
        if (!isFungusAlreadyTriggered)
        {
            noCloseFungus.SetActive(true);
            isFungusAlreadyTriggered = true;
        }
    }

    public void SetisFungusAlreadyTriggered()
    {
        
    }
}
