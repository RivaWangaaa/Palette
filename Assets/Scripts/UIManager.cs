using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject pausePanel;

    //darwbook related
    public List<GameObject> drawBookPages;
    public int currentDrawBookPageIndex;
    public GameObject drawBookPanel;
    public bool isDrawBookOpen = false;

    public static UIManager instance;

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
