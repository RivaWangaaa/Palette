using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class GiftItem : Item
{
    public bool canBeCollected;
    
    public GameObject GiftIcon;

    public GameObject ComfortingNPC;
    public string VariableForOtherNPCFlowchart;
    public string VariableForAngryNPCFlowchart;

    public override void EndInteract()
    {
        base.EndInteract();
        if (canBeCollected)
        {
            OnCollected();
        }
    }

    public override void OnCollected()
    {
        gameObject.SetActive(false);
        GiftIcon.SetActive(true);
        NPCManager.instance.NPCIsNotAngry(ComfortingNPC,
            VariableForOtherNPCFlowchart,
            VariableForAngryNPCFlowchart);
    }
}
