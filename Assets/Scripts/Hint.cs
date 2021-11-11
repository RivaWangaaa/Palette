using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hint : MonoBehaviour
{
    public bool isCollected;
    public void OnCollected()
    {
        Debug.Log("hint " + gameObject.name + " collected");
        isCollected = true;
        HintManager.instance.UpdateCollectedHints();
        gameObject.SetActive(false);
    }
}
