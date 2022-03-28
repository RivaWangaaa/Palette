using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawBookPage : MonoBehaviour
{
    //public int storyIndex;
    public DrawbookStory thisStory;

    public List<HintGroup> hintsInThisPage;

    public List<ClueGroup> clueGroupsInThisPage; 

    public void Start()
    {
        thisStory = gameObject.transform.parent.gameObject.GetComponent<DrawbookStory>();
    }

    public void trunToPreviousPage()
    {
        
        thisStory.drawbookStoryPages[thisStory.currentDrawBookStoryPageIndex].SetActive(false);
        if (thisStory.currentDrawBookStoryPageIndex == 0)
        {
            thisStory.drawbookStoryPages[thisStory.drawbookStoryPages.Count - 1].SetActive(true);
            thisStory.currentDrawBookStoryPageIndex = thisStory.drawbookStoryPages.Count - 1;
        }
        else
        {
            thisStory.drawbookStoryPages[thisStory.currentDrawBookStoryPageIndex - 1].SetActive(true);
            thisStory.currentDrawBookStoryPageIndex -= 1;
        }
    }
    public void turnToNextPage()
    {
        thisStory.drawbookStoryPages[thisStory.currentDrawBookStoryPageIndex].SetActive(false);
        if (thisStory.currentDrawBookStoryPageIndex == thisStory.drawbookStoryPages.Count - 1)
        {
            thisStory.drawbookStoryPages[0].SetActive(true);
            thisStory.currentDrawBookStoryPageIndex = 0;
        }
        else
        {
            thisStory.drawbookStoryPages[thisStory.currentDrawBookStoryPageIndex + 1].SetActive(true);
            thisStory.currentDrawBookStoryPageIndex += 1;
        }
    }
}
