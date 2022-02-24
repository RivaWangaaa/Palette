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
        GameManager.instance.EnterConversationMode();
    }
    
    public void EndInteract()
    {
        GameManager.instance.ExitConversationMode();
    }
    
    public void OnEnter()
    {
        GameManager.instance.currentControllingPlayer.GetComponent<CharacterController>().enabled = false;
        GameManager.instance.currentControllingPlayer.transform.position = enterClassroomPoint.position;
        GameManager.instance.currentControllingPlayer.GetComponent<CharacterController>().enabled = true;
        ExitClassroomController.instance.isPlayerOutsideTheClassroom = false;

    }
}
