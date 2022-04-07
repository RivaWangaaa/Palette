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
    public GameObject talkIcon;
    public GameObject eavesdropIcon;
    public GameObject giftIcon;
    public GameObject messageBox;

    public Text txt_Minute1;
    public Text txt_Minute2;

    public Text txt_PlayerCandyCount;
    public Animator candySetAnimator;
    
    public GameObject test0210GameOverPanel;

    public Animator SayDialog_Common;

    public GameObject currentShowingHintGroupDetail;

    [Header("Fungus")] 
    [SerializeField] public GameObject Dialog_SayDialog;
    [SerializeField] public GameObject Function_SayDialog;
    [SerializeField] public GameObject Menu_SayDialog;

    [Header("Pause Panel Related")] 
    public GameObject MainSceneUI;
    public GameObject ViewPausePanel3D;

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

    public void BackToDrawbookMain()
    {
        currentShowingHintGroupDetail.SetActive(false);
    }

    public void UIInitialize()
    {
        UIManager.instance.UpdateCandyCount();
        Dialog_SayDialog.SetActive(true);
        Function_SayDialog.SetActive(true);
        Menu_SayDialog.SetActive(true);
    }

}
