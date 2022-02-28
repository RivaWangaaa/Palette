using System;
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
        //flowchat = flowchartReference;
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
        flowchartReference.gameObject.SetActive(true);
        GameManager.instance.EnterConversationMode();
    }

    public void EndInteract()
    {
        flowchartReference.gameObject.SetActive(false);
        GameManager.instance.ExitConversationMode();
        
        //add time
        GameManager.instance.IncreaseTime(timeCost);
        
        if (needAnEndEvent)
        {
            NPCManager.instance.SetWayPointsByEvent(endEvent);
        }
    }

    public void OnHearingNoteSystem()
    {
        NPCManager.instance.NPCs[2].GetComponent<NPC>().hintGroupInDrawBook[0].RevealThisHint();
        NPCManager.instance.NPCs[2].GetComponent<NPC>().flowchat.SetBooleanVariable("isNoteSystemHeard", true);
    }

    public void OnHearingGoblinMyth()
    {
        //unlock storyline by eavesdropping Janitor and Teacher conversation
        UIManager.instance.drawbookStories[0].drawbookStoryPages[0].GetComponent<DrawBookPage>().hintsInThisPage[9]
            .RevealThisHint();
    }
}
