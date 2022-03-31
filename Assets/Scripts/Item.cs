using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class Item : MonoBehaviour
{
    public Flowchart observationLines;
    public GameObject popUpImage;
    
    public virtual void OnInteract()
    {
        observationLines.gameObject.SetActive(true);
        Debug.Log("interact");
        if (popUpImage != null)
        {
            popUpImage.SetActive(true);
        }
        GameManager.instance.EnterConversationMode();
        observationLines.SetStringVariable("currentPlayer", GameManager.instance.currentControllingPlayer.name);
    }
    
    public virtual void EndInteract()
    {
        observationLines.gameObject.SetActive(false);
        if (popUpImage != null)
        {
            popUpImage.SetActive(false);
        }
        GameManager.instance.ExitConversationMode();
    }

    public virtual void OnCollected()
    {
        
    }
}
