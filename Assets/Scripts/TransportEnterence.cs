using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class TransportEnterence : MonoBehaviour
{
    public Flowchart tryToEnterFlowchat;
    public Transform enterClassroomPoint;
    
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
    
    public void OnEnter()
    {
        GameManager.instance.currentControllingPlayer.GetComponent<CharacterController>().enabled = false;
        GameManager.instance.currentControllingPlayer.transform.position = enterClassroomPoint.position;
        GameManager.instance.currentControllingPlayer.GetComponent<CharacterController>().enabled = true;
        ExitClassroomController.instance.isPlayerOutsideTheClassroom = false;

    }
}
