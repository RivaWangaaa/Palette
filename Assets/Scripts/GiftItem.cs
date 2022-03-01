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

    public GameObject ComfortingNPC;
    public string VariableForOtherNPCFlowchart;
    public string VariableForAngryNPCFlowchart;
    
    public void OnInteract()
    {
        observationLines.gameObject.SetActive(true);
        if (popUpImage != null)
        {
            popUpImage.SetActive(true);
        }
        GameManager.instance.EnterConversationMode();
    }

    public void EndInteract()
    {
        observationLines.gameObject.SetActive(false);
        if (popUpImage != null)
        {
            popUpImage.SetActive(false);
        }

        if (canBeCollected)
        {
            OnCollected();
        }
        GameManager.instance.ExitConversationMode();
    }

    public void OnCollected()
    {
        gameObject.SetActive(false);
        GiftIcon.SetActive(true);
        NPCManager.instance.NPCIsNotAngry(ComfortingNPC,
            VariableForOtherNPCFlowchart,
            VariableForAngryNPCFlowchart);
    }
    
}
