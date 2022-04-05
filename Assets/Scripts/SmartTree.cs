using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class SmartTree : MonoBehaviour
{
    public static SmartTree instance;
    //use a list of sting to store all helps
    //consume candy when buy help
    //after buy help, set the string variable in flowchart and shown in fungus
    //remove certain helps when find the main storyline clues

    [SerializeField] private LeadsScriptableObject[] leadsGeneralPool;
    [SerializeField] private Flowchart flowchart;
    public LeadsScriptableObject[,] leadsPoolInOrder;

    public int leadPrice;

    private string currentShownHelp;

    public int currentLeadsPoolVerticalIndex;
    public int currentLeadsPoolHorizontalIndex;
    public int currentCollectedHintInRow;

    private void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);

            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void Start()
    {
        leadsPoolInOrder = new LeadsScriptableObject[10,10];
        foreach (var lead in leadsGeneralPool)
        {
            leadsPoolInOrder[lead.positionInLeadsPool.x, lead.positionInLeadsPool.y] = lead;
            lead.isBought = false;
            lead.isHintCollected = false;
            //Debug.LogFormat("LeadsPoolInOrder[{0},{1}] =" + leadsPoolInOrder[lead.positionInLeadsPool.x, lead.positionInLeadsPool.y].name,lead.positionInLeadsPool.x,lead.positionInLeadsPool.y);
        }
        BuyHelp();
    }

    public void BuyHelp()
    {
        //there is enough help to provide -> with enough candy-> Buy Succeed(consume candy, show help)
        //there is enough help to provide -> not enough candy -> Buy Fail(not consume candy, not show help)
        //not enough help (player already buy) -> Show Help
        
        int playerCandy = GameManager.instance.playerCandyCount;
 
        //Debug.Log("horizontalindex = " + currentLeadsPoolHorizontalIndex);
        
        for (int i = 0; i < currentLeadsPoolHorizontalIndex; i++)
        {
            LeadsScriptableObject currentLead = leadsPoolInOrder[currentLeadsPoolVerticalIndex, i];
            if (!currentLead.isBought && !currentLead.isHintCollected)
            {
                if (playerCandy >= leadPrice)
                {
                    Debug.Log("buy success");
                    //buy success, show content, break the loop and lose candy
                    GameManager.instance.playerCandyCount -= leadPrice;
                    flowchart.SetStringVariable("currentShownHelp",currentLead.leadContent);
                    flowchart.SetBooleanVariable("BuySuccess",true);
                    break;
                }
                else
                {
                    Debug.Log("buy fail, not enough candy");
                    flowchart.SetBooleanVariable("NotEnoughCandy",true);
                    break;
                }
            } 
            else if (currentLead.isBought && !currentLead.isHintCollected)
            {
                Debug.Log("buy fail, show previous lead");
                flowchart.SetStringVariable("currentShownHelp",currentLead.leadContent);
                flowchart.SetBooleanVariable("AlreadyBuy",true);
                break;
            }
        }
    }

    public void UpdateIndexInLeadsPoolInOrder()
    {
        //called when player collected a hint
        //hint collected in this row +1
        currentCollectedHintInRow++;
        if (currentCollectedHintInRow >= currentLeadsPoolHorizontalIndex)
        {
            currentLeadsPoolVerticalIndex++;
            while (leadsPoolInOrder[currentLeadsPoolVerticalIndex,currentLeadsPoolHorizontalIndex] != null)
            {
                currentLeadsPoolHorizontalIndex++;
            }
        }
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            BuyHelp();
        }
    }
}
