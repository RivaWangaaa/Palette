using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loop0EndGhostTransition : MonoBehaviour
{
    public GameObject GhostTransitionDialog;
    public GameObject mainCameraCanvas;
    public GameObject ghostTransitionCamera;
    
    public void Loop0GhostTransitionSetUp()
    {
        GhostTransitionDialog.SetActive(true);
        mainCameraCanvas.SetActive(true);
        ghostTransitionCamera.SetActive(false);
    }
}
