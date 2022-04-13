using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempAreaAudio : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("player"))
        {
            if (VFXManager.instance.isInHallway)
            {
                VFXManager.instance.isInHallway = false;
            }
            else
            {
                VFXManager.instance.isInHallway = true;
            }
        }
    }
}
