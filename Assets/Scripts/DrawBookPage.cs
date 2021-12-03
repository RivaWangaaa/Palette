using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawBookPage : MonoBehaviour
{
    public void trunToPreviousPage()
    {
        UIManager.instance.drawBookPages[UIManager.instance.currentDrawBookPageIndex].SetActive(false);
        if (UIManager.instance.currentDrawBookPageIndex == 0)
        {
            UIManager.instance.drawBookPages[UIManager.instance.drawBookPages.Count - 1].SetActive(true);
            UIManager.instance.currentDrawBookPageIndex = UIManager.instance.drawBookPages.Count - 1;
        }
        else
        {
            UIManager.instance.drawBookPages[UIManager.instance.currentDrawBookPageIndex - 1].SetActive(true);
            UIManager.instance.currentDrawBookPageIndex -= 1;
        }
    }
    public void turnToNextPage()
    {
        UIManager.instance.drawBookPages[UIManager.instance.currentDrawBookPageIndex].SetActive(false);
        if (UIManager.instance.currentDrawBookPageIndex == UIManager.instance.drawBookPages.Count - 1)
        {
            UIManager.instance.drawBookPages[0].SetActive(true);
            UIManager.instance.currentDrawBookPageIndex = 0;
        }
        else
        {
            UIManager.instance.drawBookPages[UIManager.instance.currentDrawBookPageIndex + 1].SetActive(true);
            UIManager.instance.currentDrawBookPageIndex += 1;
        }
    }
}
