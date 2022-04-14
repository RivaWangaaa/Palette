using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetMusicState : MonoBehaviour
{
    public AK.Wwise.State OnTriggerEnterState;

    private void Start()
    {
        AkSoundEngine.SetState("BackgroudMusic", "Hallway");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("player"))
        {
            OnTriggerEnterState.SetValue();
            Debug.Log("play music");
        }
    }
}
