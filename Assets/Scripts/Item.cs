using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class Item : MonoBehaviour
{
    //scripts shown on interact
    public Flowchart observationLines;
    //image shown on screen on interact
    public GameObject popUpImage;
    
    public virtual void OnInteract()
    {
        observationLines.gameObject.SetActive(true);
        //show popup image
        if (popUpImage != null)
        {
            popUpImage.SetActive(true);
        }
        //freeze player camera, disable wasd input
        GameManager.instance.EnterConversationMode();
        //set variable in flowchart
        observationLines.SetStringVariable("currentPlayer", 
            GameManager.instance.currentControllingPlayer.name);
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
