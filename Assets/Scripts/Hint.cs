using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class Hint : MonoBehaviour
{
    //0215: used to determine if is first time observed
    public bool isObserverd;

    public Flowchart observationLines;
    public GameObject popUpImage;

    public HintGroup hintGroupInDrawBook;
    public HintGroup secondHintGroupInDrawBook;

    public bool canBeSeenByJimie;
    public bool canBeSeenByPlum;

    public int observeTimeCost;

    public GameObject tutorialBlock;
    
    //when player press E to interact with this item
    public void OnObserve(GameObject currentPlayer)
    {
        Debug.Log("hint " + gameObject.name + " observe");
        
        //0215: only increase candy first time observe


        //0125:new hintgroup method
        if (hintGroupInDrawBook != null)
        {
            hintGroupInDrawBook.RevealThisHint();
        }

        observationLines.gameObject.SetActive(true);
        observationLines.SetStringVariable("currentPlayer", currentPlayer.name);
        
        if (popUpImage != null)
        {
            popUpImage.SetActive(true);
        }

        GameManager.instance.EnterConversationMode();
    }

    public void EndObserve()
    {
        TriggerTutorial();

        if (popUpImage != null)
        {
            popUpImage.SetActive(false);
        }
        GameManager.instance.ExitConversationMode();
        //GameManager.instance.IncreaseTime(observeTimeCost);
        if (!isObserverd)
        {
            isObserverd = true;
            GameManager.instance.IncreaseCandy(1);
        }
        observationLines.gameObject.SetActive(false);

    }
    public void TriggerTutorial()
    {
        if (tutorialBlock != null)
        {
            tutorialBlock.SetActive(true);
            tutorialBlock = null;
        }
    }

    public void SetTutorialBlock(GameObject Block)
    {
        tutorialBlock = Block;
    }

    public void OnObserveBarbie()
    {
        //unlock conversation branch barbie with Flora
        NPCManager.instance.NPCs[1].GetComponent<NPC>().flowchat.SetBooleanVariable("isBarbieFound", true);
    }
    
    public void OnObserveHair()
    {
        //lock conversation branch with Emi
        NPCManager.instance.NPCs[3].GetComponent<NPC>().flowchat.SetBooleanVariable("isHairFound", true);
        //unlock flora's hair
        NPCManager.instance.NPCs[1].GetComponent<NPC>().observableParts[0].SetActive(true);
    }

    public void OnObserveFloraDrawbook()
    {
        //can now observe key
        HintManager.instance.observableObject[8].GetComponent<BoxCollider>().enabled = true;
    }
    
    public void OnOpenFloraDrawbook()
    {
        secondHintGroupInDrawBook.RevealThisHint();
    }
    
    public void OnObserveFloraKey()
    {
        //can now open the drawing book
        HintManager.instance.observableObject[7].transform.GetChild(0).gameObject.GetComponent<Flowchart>().SetBooleanVariable("isKeyCollected",true);
    }

    public void OnSingleStickerCollected()
    {
        HintManager.instance.stickerCounts++;
        if (HintManager.instance.stickerCounts == 3)
        {
            //can now observe stack of stickers
            HintManager.instance.observableObject[9].GetComponent<BoxCollider>().enabled = true;
        }
    }

    public void OnStickersCollected()
    {
        //unlock conversation branch sticker with Flora
        NPCManager.instance.NPCs[1].GetComponent<NPC>().flowchat.SetBooleanVariable("isStickersFound", true);
    }

    public void OnSinglePitClueGathered()
    {
        HintManager.instance.pitCluesCounts++;
        if (HintManager.instance.pitCluesCounts == 3)
        {
            NPCManager.instance.NPCs[0].GetComponent<NPC>().flowchat.SetBooleanVariable("isFoundTheButton",true);
        }
    }

    public void OnObserveIanShirt()
    {
        HintManager.instance.pitCluesCounts++;
        if (HintManager.instance.pitCluesCounts == 3)
        {
            NPCManager.instance.NPCs[0].GetComponent<NPC>().flowchat.SetBooleanVariable("isFoundTheButton",true);
        }
    }

    public void OnCollectDiary()
    {
        //if player has not collected vick list, active a new dialog branch with Janitor
        if (!UIManager.instance.drawbookStories[0].drawbookStoryPages[0].GetComponent<DrawBookPage>().hintsInThisPage[1].revrealedIcon.activeSelf)
        {
            NPCManager.instance.NPCs[5].GetComponent<NPC>().flowchat.SetBooleanVariable("isFoundDairyWithoutList",true);
        }
    }
    
    public void OnCollectVickList()
    {
        //disable the dialog branch with janitor about the list
        NPCManager.instance.NPCs[5].GetComponent<NPC>().flowchat.SetBooleanVariable("isFoundDairyWithoutList",false);
    }

    public void GetSubhintOnDiary()
    {
        UIManager.instance.drawbookStories[0].drawbookStoryPages[0].GetComponent<DrawBookPage>().hintsInThisPage[2]
            .GetSubHints();
    }

    public void OnObserveNapBook()
    {
        //unlock conversation branch  with Flora
        NPCManager.instance.NPCs[1].GetComponent<NPC>().flowchat.SetBooleanVariable("isPersonalStuffFound", true);
        UIManager.instance.drawbookStories[0].drawbookStoryPages[0].GetComponent<DrawBookPage>().hintsInThisPage[7]
            .RevealThisHint();
    }
    
    public void OnObserveFloraPersonalStuff()
    {
        //unlock conversation branch sticker with Flora
        NPCManager.instance.NPCs[1].GetComponent<NPC>().flowchat.SetBooleanVariable("isNapBookFound", true);
        UIManager.instance.drawbookStories[0].drawbookStoryPages[0].GetComponent<DrawBookPage>().hintsInThisPage[8]
            .RevealThisHint();
        
    }
    
    public void OnObserveFloraPicture()
    {
        NPCManager.instance.NPCs[1].GetComponent<NPC>().flowchat.SetBooleanVariable("isFloraPictureFound", true);
        UIManager.instance.drawbookStories[0].drawbookStoryPages[0].GetComponent<DrawBookPage>().hintsInThisPage[10]
            .RevealThisHint();
        
    }

    public void OnObserveOnePage()
    {
        //choose 'page' in flora's diary
        UIManager.instance.drawbookStories[0].drawbookStoryPages[0].GetComponent<DrawBookPage>().hintsInThisPage[5]
            .RevealThisHint();
    }

    public void OnObserveMotherLeft()
    {
        NPCManager.instance.NPCs[1].GetComponent<NPC>().flowchat.SetBooleanVariable("isMotherLeftFound", true);
    }
    
    public void OnObserveFatherBeat()
    {
        HintManager.instance.observableObject[10].GetComponent<Hint>().observationLines.SetBooleanVariable("isFoundFatherBeat", true);
    }

    public void OnObserveFloraBag()
    {
        UIManager.instance.drawbookStories[0].drawbookStoryPages[0].GetComponent<DrawBookPage>().hintsInThisPage[6]
            .RevealThisHint();
    }
}
