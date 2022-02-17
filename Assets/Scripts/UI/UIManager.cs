using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject pausePanel;

    //darwbook related
    public List<DrawbookStory> drawbookStories;
    public int currentStory;
    public GameObject drawBookPanel;
    public bool isDrawBookOpen = false;

    public static UIManager instance;

    public GameObject crosshair;
    public GameObject observeIcon;
    public GameObject moveIcon;
    public GameObject messageBox;

    public Text txt_Minute1;
    public Text txt_Minute2;

    public GameObject clueGroupDetail_Left;
    public GameObject cludGroupDetail_Right;

    public Text txt_PlayerCandyCount;
    public Animator candySetAnimator;
    
    public GameObject test0210GameOverPanel;
    
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

    public void UpdateCandyCount()
    {
        txt_PlayerCandyCount.text = GameManager.instance.playerCandyCount.ToString();
        candySetAnimator.SetTrigger("CandyIncrease");
    }

}
