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

    public Animator eavesdropCharacterLeft;
    public Animator eavesdropCharacterRight;

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

    public void StartPlayAnimation()
    {
        eavesdropCharacterLeft.SetTrigger("StartDialog");
        eavesdropCharacterRight.SetTrigger("StartDialog");
        UIManager.instance.SayDialog_Common.SetTrigger("StartDialog");
    }
    
    public void ShowAnimation()
    {
        eavesdropCharacterRight.gameObject.SetActive(true); 
        eavesdropCharacterLeft.gameObject.SetActive(true); 
        GameManager.instance.currentControllingPlayerConversationModeCharacter.gameObject.SetActive(true);
    }
    
    public void HideAnimation()
    {
        eavesdropCharacterRight.gameObject.SetActive(false); 
        eavesdropCharacterLeft.gameObject.SetActive(false); 
        GameManager.instance.currentControllingPlayerConversationModeCharacter.gameObject.SetActive(false);
    }
    
    public void OnInteract()
    {
        ShowAnimation();
        UIManager.instance.SayDialog_Common.gameObject.SetActive(true);
        flowchartReference.gameObject.SetActive(true);
        GameManager.instance.EnterConversationMode();
    }

    public void EndInteract()
    {
        ShowAnimation();
        flowchartReference.gameObject.SetActive(false);
        GameManager.instance.ExitConversationMode();
        
        //add time
        GameManager.instance.IncreaseTime(timeCost);
        
        if (needAnEndEvent)
        {
            NPCManager.instance.SetWayPointsByEvent(endEvent);
        }
        
        eavesdropCharacterLeft.SetTrigger("EndDialog");
        eavesdropCharacterRight.SetTrigger("EndDialog");
        GameManager.instance.currentControllingPlayerConversationModeCharacter.SetTrigger("EndDialog");
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
    
    public void OnHearingFloraBullyVick()
    {
        
    }
}
