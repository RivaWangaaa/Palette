using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class NPC : MonoBehaviour
{
    public bool isCollected;
    public Flowchart flowchat;

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
    }
}
