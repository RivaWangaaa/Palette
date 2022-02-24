using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class OneWayDoor : MonoBehaviour
{

    [Header("flowchats")]
    public Flowchart tryToEnterFlowchat;
    public Flowchart tryToExitFlowchat;

    [Header("teleport point")]
    public Transform enterClassroomPoint;

    public bool isTryingEnterFromInside;

    public void playerInteractWithTheClassroomDoor()
    {
        OnInteract();
        if (!ExitClassroomController.instance.isPlayerOutsideTheClassroom)
        {
            tryToExitFlowchat.gameObject.SetActive(true);
        }
        else
        {
            tryToEnterFlowchat.gameObject.SetActive(true);
        }

    }

    public void onEnterClassroom()
    {
        GameManager.instance.currentControllingPlayer.GetComponent<CharacterController>().enabled = false;
        GameManager.instance.currentControllingPlayer.transform.position = enterClassroomPoint.position;
        GameManager.instance.currentControllingPlayer.GetComponent<CharacterController>().enabled = true;
        ExitClassroomController.instance.isPlayerOutsideTheClassroom = false;

    }

    public void OnInteract()
    {
        GameManager.instance.EnterConversationMode();
    }

    
    public void EndInteract()
    {
        GameManager.instance.ExitConversationMode();
    }
}
