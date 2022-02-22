using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class GiftItem : MonoBehaviour
{
    public bool canBeCollected;

    public Flowchart observationLines;
    public GameObject popUpImage;
    public GameObject GiftIcon;

    public void OnInteract()
    {
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

    public void EndInteract()
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

        if (canBeCollected)
        {
            OnCollected();
        }
    }

    public void OnCollected()
    {
        gameObject.SetActive(false);
        GiftIcon.SetActive(true);
        NPCManager.instance.NPCIsNotAngry(NPCManager.instance.NPCs[1],
            "FloraIsAngry",
            "isHaveGift");
    }
    
}
