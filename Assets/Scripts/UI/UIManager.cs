﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject pausePanel;

    //darwbook related
    public List<GameObject> drawbookStories;
    public int currentStory;
    public GameObject drawBookPanel;
    public bool isDrawBookOpen = false;

    public static UIManager instance;

    public GameObject crosshair;
    public GameObject observeIcon;

    public Text txt_Time;

    void Awake()
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

    //attached to the 'DrawBook' Button on the PausePanel
    public void DrawBook()
    {
        isDrawBookOpen = !isDrawBookOpen;
        if (isDrawBookOpen)
        {
            drawBookPanel.SetActive(true);
        }
        else
        {
            drawBookPanel.SetActive(false);
        }

    }

}