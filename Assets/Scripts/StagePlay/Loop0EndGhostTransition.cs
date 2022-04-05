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
        GameManager.instance.currentControllingPlayer.transform.GetChild(0).gameObject.SetActive(true);
        loop1Toturial.SetActive(true);
        levelDoor.SetActive(true);
        Plum.GetComponent<CharacterController>().enabled = true;
        gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            Loop1Reset();
        }
    }
}
