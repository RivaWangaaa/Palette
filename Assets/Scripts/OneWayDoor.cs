using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class OneWayDoor : MonoBehaviour
{

    [Header("flowchats")]
    public Flowchart forbidToExitFlowchat;
    public Flowchart tryToEnterFlowchat;
    public Flowchart tryToComeOutFlowchat;

    [Header("bools for different chats")]
    public bool isSomeoneOutThere;
    public bool isPlayerOutsideTheClassroom;
    public bool DoestryToComeOut;
    
    [Header("teleport point")]
    public Transform enterClassroomPoint;
    public Transform outClassroomPoint;

    [Header("Countdown related")]
    public int timePlayerGoOut;
    public int playerOutTimeLong;

    private void Update()
    {
        if(isPlayerOutsideTheClassroom && timePlayerGoOut + 3 == GameManager.instance.currentLoopTimeMinute)
        {
            onEnterClassroom();
            tryToEnterFlowchat.gameObject.SetActive(false);
            //forbidToExitFlowchat.gameObject.SetActive(true);
        }
    }


    public void playerInteractWithTheClassroomDoor()
    {
        OnInteract();
        if(!isPlayerOutsideTheClassroom)
        {
 
                tryToComeOutFlowchat.gameObject.SetActive(true);
                
                forbidToExitFlowchat.gameObject.SetActive(true);
        }
        else
        {
            tryToEnterFlowchat.gameObject.SetActive(true);
        }
    }

    public void playerPermitToExitTheRoom()
    {
        DoestryToComeOut = true;
    }

    public void onExitClassroom()
    {
        GameManager.instance.currentControllingPlayer.GetComponent<CharacterController>().enabled = false;
        GameManager.instance.currentControllingPlayer.transform.position = outClassroomPoint.position;
        GameManager.instance.currentControllingPlayer.GetComponent<CharacterController>().enabled = true;
        isPlayerOutsideTheClassroom = true;
        timePlayerGoOut = GameManager.instance.currentLoopTimeMinute;
    }

    public void onEnterClassroom()
    {
        GameManager.instance.currentControllingPlayer.GetComponent<CharacterController>().enabled = false;
        GameManager.instance.currentControllingPlayer.transform.position = enterClassroomPoint.position;
        GameManager.instance.currentControllingPlayer.GetComponent<CharacterController>().enabled = true;
        isPlayerOutsideTheClassroom = false;
        DoestryToComeOut = false;
        //playerOutTimeLong = 0;
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
