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
        NPCManager.instance.isHavingConversation = true;

        //lock player's camera when having a conversation
        GameManager.instance.currentControllingPlayer.GetComponent<MouseLook>().sensitivityX = 0;
        GameManager.instance.currentControllingPlayer.transform.GetChild(0).gameObject.GetComponent<MouseLook>().sensitivityY = 0;
        GameManager.instance.currentControllingPlayer.transform.GetChild(0).gameObject.GetComponent<LockMouse>().LockCursor(false);
    }

    
    public void EndInteract()
    {
        NPCManager.instance.isHavingConversation = false;
        GameManager.instance.currentControllingPlayer.GetComponent<MouseLook>().sensitivityX = 8;
        GameManager.instance.currentControllingPlayer.transform.GetChild(0).gameObject.GetComponent<MouseLook>().sensitivityY = 8;
        GameManager.instance.currentControllingPlayer.transform.GetChild(0).gameObject.GetComponent<LockMouse>().LockCursor(true);
    }
}
