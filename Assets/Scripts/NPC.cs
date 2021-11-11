using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public bool isCollected;
    public void OnInteract()
    {
        Debug.Log("character " + gameObject.name + " interacted");
        isCollected = true;
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
        NPCManager.instance.UpdateCollectedHints();
    }
}
