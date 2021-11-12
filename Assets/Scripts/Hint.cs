using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hint : MonoBehaviour
{
    //used by HintManager to learn if this item is collected
    //Nate: I always though it could be written in a more elegent way 
    public bool isCollected;

    //when player press E to interact with this item
    public void OnCollected()
    {
        Debug.Log("hint " + gameObject.name + " collected");
        isCollected = true;
        //update the statues of each item in HintManager
        HintManager.instance.UpdateCollectedHints();
        gameObject.SetActive(false);
    }
}
