using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class Hint : MonoBehaviour
{
    //used by HintManager to learn if this item is collected
    //Nate: I always though it could be written in a more elegent way 
    public bool isCollected;
    public GameObject iconInDrawBook;
    public Flowchart observationLines;
    public GameObject popUpImage;

    public bool canBeSeenByJimie;
    public bool canBeSeenByPlum;
    public bool canBeSeenByChunk;

    //when player press E to interact with this item
    public void OnObserve()
    {
        Debug.Log("hint " + gameObject.name + " collected");
        isCollected = true;
        //update the statues of each item in HintManager
        HintManager.instance.UpdateCollectedHints();
        iconInDrawBook.SetActive(true);
        observationLines.gameObject.SetActive(true);
        if (popUpImage != null)
        {
            popUpImage.SetActive(true);
        }
        NPCManager.instance.isHavingConversation = true;
        GameManager.instance.currentControllingPlayer.GetComponent<MouseLook>().sensitivityX = 0;
        GameManager.instance.currentControllingPlayer.transform.GetChild(0).gameObject.GetComponent<MouseLook>()
            .sensitivityY = 0;
        GameManager.instance.currentControllingPlayer.transform.GetChild(0).gameObject.GetComponent<LockMouse>()
            .LockCursor(false);
    }

    public void EndObserve()
    {
        observationLines.gameObject.SetActive(false);
        if (popUpImage != null)
        {
            popUpImage.SetActive(false);
        }
        GameManager.instance.currentControllingPlayer.GetComponent<MouseLook>().sensitivityX = 8;
        GameManager.instance.currentControllingPlayer.transform.GetChild(0).gameObject.GetComponent<MouseLook>()
            .sensitivityY = 8;
        GameManager.instance.currentControllingPlayer.transform.GetChild(0).gameObject.GetComponent<LockMouse>()
            .LockCursor(true);
        NPCManager.instance.isHavingConversation = false;

    }

    public void OnObserveBarbie()
    {
        //unlock conversation branch with Flora
        NPCManager.instance.NPCs[1].GetComponent<NPC>().flowchat.SetBooleanVariable("isBarbieFound", true);
    }
    
    public void OnObserveHair()
    {
        //lock conversation branch with Emi
        NPCManager.instance.NPCs[3].GetComponent<NPC>().flowchat.SetBooleanVariable("isHairFound", true);
        //unlock flora's hair
        NPCManager.instance.NPCs[1].GetComponent<NPC>().observableParts[0].SetActive(true);
    }

}
