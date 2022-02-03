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
    public List<Transform> wayPoints;

    //used to store how long NPC is standing
    private float currentStopTime;
    //used to store where NPC is Standing
    private int currentWayPointIndex;

    public SpriteRenderer pose;

    public GameObject talkIcon;
    public GameObject eavesdropIcon;

    public List<GameObject> hintsInDrawBook;
    public List<HintGroup> hintGroupInDrawBook;

    public bool canBeEavesdroped;
    public bool isWithInTalkDistance;

    public List<GameObject> observableParts;

    public bool shouldMoveThisEvent;

    private void Update()
    {
        if(wayPoints.Count == 0 || currentWayPointIndex == wayPoints.Count || NPCManager.instance.isHavingConversation)
        {
            //NPC stands still
        }
        else if(wayPoints.Count == 1)
        {
            transform.position = wayPoints[0].position;
            currentWayPointIndex++;
            wayPoints.Clear();
            currentWayPointIndex = 0;
        }
        else
        {
            //NPC has waypoints remaining, they should keep going
            currentStopTime += Time.deltaTime;
            if(currentStopTime >= (float)(60 / GameManager.instance.timeModifier) / (float)wayPoints.Count)
            {
                //Debug.Log(60/GameManager.instance.timeModifier + "," + wayPoints.Count + "," + (float)(60 / GameManager.instance.timeModifier) / (float)wayPoints.Count);
                transform.position = wayPoints[currentWayPointIndex].position;
                currentStopTime = 0;
                currentWayPointIndex ++;
                if(currentWayPointIndex == wayPoints.Count)
                {
                    wayPoints.Clear();
                    currentWayPointIndex = 0;
                }
            }
        }

        transform.LookAt(GameManager.instance.currentControllingPlayer.transform);
    }

    public void OnInteract(GameObject currentPlayer)
    {
        //Debug.Log("character " + gameObject.name + " interacted");
        //this would be written in the flowchart, coz player is not 100% get the hint in the conversation
        isCollected = true;
        //disable the VFX on NPC
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
        //active the fungus on NPC
        flowchat.gameObject.SetActive(true);
        //NPC will react differently based on who they are talking to
        //every flowchat for NPC has a string variable to help NPC know who they are talking to
        flowchat.SetStringVariable("currentPlayer", currentPlayer.name);
        NPCManager.instance.UpdateCollectedHints();
        
        if(GameManager.instance.currentControllingPlayer.GetComponent<Player>().isEavesdroping)
        {
            Debug.Log("start dropping");
            flowchat.SetBooleanVariable("IsEavesdropping", true);
        }

        //lock player's camera when having a conversation
        NPCManager.instance.isHavingConversation = true;
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
        flowchat.gameObject.SetActive(false);
        //Debug.Log("end interaction");
        if (GameManager.instance.currentControllingPlayer.GetComponent<Player>().isEavesdroping)
        {
            Debug.Log("end dropping");
            GameManager.instance.currentControllingPlayer.GetComponent<Player>().isEavesdroping = false;
            flowchat.SetBooleanVariable("IsEavesdropping", false);
        }
    }

    public void GetHintBarbie()
    {
        //Flore, Img_Flora_Hint1
        hintsInDrawBook[0].SetActive(true);
    }

    public void GetHintHair()
    {
        //Vick, 
        hintsInDrawBook[0].SetActive(true);
    }
    
    public void GetHintNoteSystem()
    {
        //Vick tell the note system
        hintGroupInDrawBook[1].RevealThisHint();
    }
    
    public void GetHintDrawingBook()
    {
        //Flore, 
        hintsInDrawBook[1].SetActive(true);
    }

    public void GetHintStickers()
    {
        //Flore tell the pig stuff about Vik
        hintGroupInDrawBook[0].RevealThisHint();
    }
    
    public void GetHintButton()
    {
        //Ian will tell if you find who bury it
        hintGroupInDrawBook[0].RevealThisHint();
    }
    public void GetHintPit()
    {
        //Flora lost something she burried
        hintGroupInDrawBook[1].RevealThisHint();
    }

    public void GetSubHintsOnDairy()
    {
        //Ask Janitor about the diary
        UIManager.instance.drawbookStories[0].drawbookStoryPages[0].GetComponent<DrawBookPage>().hintsInThisPage[0]
            .GetSubHints();
    }
    
    public void GetSubHintsOnList()
    {
        //Ask Janitor about the List
        UIManager.instance.drawbookStories[0].drawbookStoryPages[0].GetComponent<DrawBookPage>().hintsInThisPage[1]
            .GetSubHints();
    }
    
    public void GetSubHintsOnKey()
    {
        //Ask Janitor about the List
        UIManager.instance.drawbookStories[0].drawbookStoryPages[0].GetComponent<DrawBookPage>().hintsInThisPage[3]
            .GetSubHints();
    }

    public void GetHintOnSecretPlace()
    {
        //Flora Tells about the secret place
        UIManager.instance.drawbookStories[0].drawbookStoryPages[0].GetComponent<DrawBookPage>().hintsInThisPage[4]
            .RevealThisHint();
    }

    public void GetHintOnMotherleft()
    {
        hintGroupInDrawBook[2].RevealThisHint();
    }
}
