﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class NPC : MonoBehaviour
{
    public bool isCollected;
    public Flowchart flowchat;

    //time NPC stops at each waypoint
    public float maxStopTime = 2f;
    public Transform[] wayPoints;

    //used to store how long NPC is standing
    private float currentStopTime;
    //used to store where NPC is Standing
    private int currentWayPointIndex;

    private void Update()
    {
        if(wayPoints.Length == 0 || currentWayPointIndex == wayPoints.Length || NPCManager.instance.isHavingConversation)
        {
            //NPC stands still
        }
        else
        {
            //NPC has waypoints remaining, they should keep going
            currentStopTime += Time.deltaTime;
            if(currentStopTime >= maxStopTime)
            {
                transform.position = wayPoints[currentWayPointIndex].position;
                currentStopTime = 0;
                currentWayPointIndex ++;
            }
        }
    }

    public void OnInteract(GameObject currentPlayer)
    {
        Debug.Log("character " + gameObject.name + " interacted");
        //this would be written in the flowchat, coz player is not 100% get the hint in the conversation
        isCollected = true;
        //disable the VFX on NPC
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
        //active the fungus on NPC
        flowchat.gameObject.SetActive(true);
        //NPC will react differently based on who they are talking to
        //every flowchat for NPC has a string variable to help NPC know who they are talking to
        flowchat.SetStringVariable("currentPlayer", currentPlayer.name);
        NPCManager.instance.UpdateCollectedHints();
        NPCManager.instance.isHavingConversation = true;

        //lock player's camera when having a conversation
        GameManager.instance.currentControllingPlayer.GetComponent<MouseLook>().sensitivityX = 0;
        GameManager.instance.currentControllingPlayer.transform.GetChild(0).gameObject.GetComponent<MouseLook>().sensitivityY = 0;
        GameManager.instance.currentControllingPlayer.transform.GetChild(0).gameObject.GetComponent<LockMouse>().LockCursor(false);
    }

    public void EndInteract()
    {
        GameManager.instance.currentControllingPlayer.GetComponent<MouseLook>().sensitivityX = 8;
        GameManager.instance.currentControllingPlayer.transform.GetChild(0).gameObject.GetComponent<MouseLook>().sensitivityY = 8;
        GameManager.instance.currentControllingPlayer.transform.GetChild(0).gameObject.GetComponent<LockMouse>().LockCursor(true);
        NPCManager.instance.isHavingConversation = false;
        Debug.Log("end interaction");
    }
}
