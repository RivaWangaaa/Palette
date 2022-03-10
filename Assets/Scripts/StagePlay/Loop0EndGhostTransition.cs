using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loop0EndGhostTransition : MonoBehaviour
{
    public GameObject GhostTransitionDialog;
    public GameObject mainCameraCanvas;
    public GameObject ghostTransitionCamera;
    public GameObject loop1Toturial;
    
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
    }
}
