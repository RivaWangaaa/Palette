using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loop0EndGhostTransition : MonoBehaviour
{
    public GameObject GhostTransitionDialog;
    public GameObject mainCameraCanvas;
    public GameObject ghostTransitionCamera;
    public GameObject loop1Toturial;
    public GameObject levelDoor;
    public GameObject Plum;
    
    public void Loop0GhostTransitionSetUp()
    {
        GhostTransitionDialog.SetActive(true);
        mainCameraCanvas.SetActive(true);
        ghostTransitionCamera.SetActive(false);
    }

    public void Loop1Reset()
    {
        GameManager.instance.LoopReset();
        gameObject.SetActive(false);
    }
}
