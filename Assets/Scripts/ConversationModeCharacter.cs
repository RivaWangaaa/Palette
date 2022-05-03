using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConversationModeCharacter : MonoBehaviour
{
    public void HideAnimation()
    {
        GameManager.instance.currentControllingPlayerConversationModeCharacter.gameObject.SetActive(false);
        UIManager.instance.SayDialog_Common.gameObject.SetActive(false);
        gameObject.SetActive(false);
        Debug.Log(gameObject.name);
        Debug.Log("disable animations");
    }
}
