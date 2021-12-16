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

    //when player press E to interact with this item
    public void OnObserve()
    {
        Debug.Log("hint " + gameObject.name + " collected");
        isCollected = true;
        //update the statues of each item in HintManager
        HintManager.instance.UpdateCollectedHints();
        iconInDrawBook.SetActive(true);
        observationLines.gameObject.SetActive(true);
        
        NPCManager.instance.isHavingConversation = true;
        GameManager.instance.currentControllingPlayer.GetComponent<MouseLook>().sensitivityX = 0;
        GameManager.instance.currentControllingPlayer.transform.GetChild(0).gameObject.GetComponent<MouseLook>().sensitivityY = 0;
        GameManager.instance.currentControllingPlayer.transform.GetChild(0).gameObject.GetComponent<LockMouse>().LockCursor(false);
    }

    public void EndObserve()
    {
        observationLines.gameObject.SetActive(false);
        
        GameManager.instance.currentControllingPlayer.GetComponent<MouseLook>().sensitivityX = 8;
        GameManager.instance.currentControllingPlayer.transform.GetChild(0).gameObject.GetComponent<MouseLook>().sensitivityY = 8;
        GameManager.instance.currentControllingPlayer.transform.GetChild(0).gameObject.GetComponent<LockMouse>().LockCursor(true);
        NPCManager.instance.isHavingConversation = false;
    }
}
