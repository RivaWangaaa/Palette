﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class CommonConversation : MonoBehaviour
{
    public GameObject chatIcon;
    //Yanxi: Made 'flowchat' static to be used in Loop1; Added flowchartReference to assign static flowchart. 
    public static Flowchart flowchat;
    public Flowchart flowchartReference;
    
    public int timeCost;

    public bool needAnEndEvent;
    public GameObject endEvent;

    //Yanxi: Added Start() to assign flowchat onto static flowchat, so it can be used in Loop1 script. 
    private void Start()
    {
        flowchat = flowchartReference;
    }

    private void Update()
    {
        if (gameObject.CompareTag("commonConversationLong"))
        {
            if (Vector3.Distance(GameManager.instance.currentControllingPlayer.transform.position,
                    gameObject.transform.position) >= 3)
            {
                GetComponent<BoxCollider>().enabled = true;
            }
            else
            {
                GetComponent<BoxCollider>().enabled = false;
            }
        }

    }

    public void OnInteract()
    {

            flowchat.gameObject.SetActive(true);
            NPCManager.instance.isHavingConversation = true;
            GameManager.instance.currentControllingPlayer.GetComponent<MouseLook>().sensitivityX = 0;
            GameManager.instance.currentControllingPlayer.transform.GetChild(0).gameObject.GetComponent<MouseLook>().sensitivityY = 0;
            GameManager.instance.currentControllingPlayer.transform.GetChild(0).gameObject.GetComponent<LockMouse>().LockCursor(false);

    }

    public void EndInteract()
    {
        flowchat.gameObject.SetActive(false);
        GameManager.instance.currentControllingPlayer.GetComponent<MouseLook>().sensitivityX = 8;
        GameManager.instance.currentControllingPlayer.transform.GetChild(0).gameObject.GetComponent<MouseLook>().sensitivityY = 8;
        GameManager.instance.currentControllingPlayer.transform.GetChild(0).gameObject.GetComponent<LockMouse>().LockCursor(true);
        NPCManager.instance.isHavingConversation = false;
        
        //add time
        GameManager.instance.currentLoopTimeMinute += timeCost;
        if (needAnEndEvent)
        {
            NPCManager.instance.SetWayPointsByEvent(endEvent);
        }
    }
}
