using System.Collections;
using System.Collections.Generic;
using Fungus;
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
    public GameObject Stage;

    [Header("Profile Book")]
    public GameObject[] profileBookPages;
    public GameObject whiteboard;
    
    
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
        UpdateCandyCount();
        Dialog_SayDialog.SetActive(true);
        Function_SayDialog.SetActive(true);
        Menu_SayDialog.SetActive(true);
    }

    public void DisableFungusDialogInPausePanel3D()
    {
        //hide Saydialog and character animations
        Dialog_SayDialog.GetComponent<Canvas>().targetDisplay = 1;
        Function_SayDialog.GetComponent<Canvas>().targetDisplay = 1;
        Menu_SayDialog.GetComponent<Canvas>().targetDisplay = 1;
        Stage.GetComponent<Canvas>().targetDisplay = 1;
        //disable dialog click
        Dialog_SayDialog.GetComponent<DialogInput>().clickMode = ClickMode.Disabled;
        Function_SayDialog.GetComponent<DialogInput>().clickMode = ClickMode.Disabled;
    }

    public void EnableFungusDialogInPausePanel3D()
    {
        Dialog_SayDialog.GetComponent<Canvas>().targetDisplay = 0;
        Function_SayDialog.GetComponent<Canvas>().targetDisplay = 0;
        Menu_SayDialog.GetComponent<Canvas>().targetDisplay = 0;
        Stage.GetComponent<Canvas>().targetDisplay = 0;
        Dialog_SayDialog.GetComponent<DialogInput>().clickMode = ClickMode.ClickAnywhere;
        Function_SayDialog.GetComponent<DialogInput>().clickMode = ClickMode.ClickAnywhere;
    }

    //called when open profile book
    public void OpenProfilePage(int profileBookIndex)
    {
        whiteboard.SetActive(true);
        for(int i = 0; i <= profileBookPages.Length; i++)
        {
            if (i == profileBookIndex)
            {
                profileBookPages[i].SetActive(true);
            }
            else
            {
                profileBookPages[i].SetActive(false);
            }
        }
    }
}
