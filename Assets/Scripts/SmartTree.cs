using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class SmartTree : MonoBehaviour
{

    //use a list of sting to store all helps
    //consume candy when buy help
    //after buy help, set the string variable in flowchart and shown in fungus
    //remove certain helps when find the main storyline clues

    [SerializeField] private LeadsScriptableObject[] leadsGeneralPool;
    [SerializeField] private Flowchart flowchart;
    public LeadsScriptableObject[,] leadsPoolInOrder;

    private string currentShownHelp;

    public void Start()
    {
        leadsPoolInOrder = new LeadsScriptableObject[10,10];
        foreach (var lead in leadsGeneralPool)
        {
            leadsPoolInOrder[lead.positionInLeadsPool.x, lead.positionInLeadsPool.y] = lead;
            Debug.LogFormat("LeadsPoolInOrder[{0},{1}] =" + leadsPoolInOrder[lead.positionInLeadsPool.x, lead.positionInLeadsPool.y].name,lead.positionInLeadsPool.x,lead.positionInLeadsPool.y);
        }
    }

    public void BuyHelp()
    {
        //there is enough help to provide -> with enough candy-> Buy Succeed(consume candy, show help)
        //there is enough help to provide -> not enough candy -> Buy Fail(not consume candy, not show help)
        //not enough help (player already buy) -> Show Help
    }

    public void SetHelpTextInSayCommand()
    {
        
    }
    
}
