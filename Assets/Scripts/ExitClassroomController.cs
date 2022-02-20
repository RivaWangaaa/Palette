using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class ExitClassroomController : MonoBehaviour
{
    public static ExitClassroomController instance;
    void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);

            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    [Header("flowchats")]
    public Flowchart forbidToExitFlowchat;
    public Flowchart permitToExitFlowchat;
    public Flowchart tryToEnterFlowchat;

    [Header("bools for different chats")]
    public bool isSomeoneOutThere;
    public bool isPlayerHasThePermision;
    public bool isPlayerOutsideTheClassroom;
    
    [Header("teleport point")]
    public Transform enterClassroomPoint;
    public Transform outClassroomPoint;

    [Header("Countdown related")]
    public int timePlayerGoOut;
    public int playerOutTimeLong;

    private void Update()
    {
        if(isPlayerOutsideTheClassroom && timePlayerGoOut + 5 == GameManager.instance.currentLoopTimeMinute)
        {
            onEnterClassroom();
            tryToEnterFlowchat.gameObject.SetActive(false);
            //forbidToExitFlowchat.gameObject.SetActive(true);
        }
    }
    public void oneKidExitsTheRoom()
    {
        permitToExitFlowchat.SetBooleanVariable("IsSomeoneOutThere", true);
        forbidToExitFlowchat.SetBooleanVariable("IsSomeoneOutThere", true);
        NPCManager.instance.NPCs[4].GetComponent<NPC>().flowchat.SetBooleanVariable("IsSomeoneOutThere", true);
        isSomeoneOutThere = true;
        isPlayerHasThePermision = false;

    }

    public void oneKidComesBackTheRoom()
    {
        permitToExitFlowchat.SetBooleanVariable("IsSomeoneOutThere", false);
        forbidToExitFlowchat.SetBooleanVariable("IsSomeoneOutThere", false);
        NPCManager.instance.NPCs[4].GetComponent<NPC>().flowchat.SetBooleanVariable("IsSomeoneOutThere", false);
        isSomeoneOutThere = false;
    }

    public void playerInteractWithTheClassroomDoor()
    {
        OnInteract();
        if(!isPlayerOutsideTheClassroom)
        {
            if (isPlayerHasThePermision)
            {
                permitToExitFlowchat.gameObject.SetActive(true);
            }
            else
            {
                forbidToExitFlowchat.gameObject.SetActive(true);
            }
        }
        else
        {
            tryToEnterFlowchat.gameObject.SetActive(true);
        }
    }

    public void playerPermitToExitTheRoom()
    {
        isPlayerHasThePermision = true;
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
        isPlayerHasThePermision = false;
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
