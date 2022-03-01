using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConversationModeCharacter : MonoBehaviour
{
    public void HideAnimation()
    {
        GameManager.instance.currentControllingPlayerConversationModeCharacter.gameObject.SetActive(false);
        gameObject.SetActive(false);
    }
}
