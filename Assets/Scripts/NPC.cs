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
        isCollected = true;
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
        flowchat.gameObject.SetActive(true);
        flowchat.SetStringVariable("currentPlayer", currentPlayer.name);
        NPCManager.instance.UpdateCollectedHints();
    }
}
