using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private float currentLoopTimeFloat;
    public int currentLoopTimeSecond;
    public int currentLoopTimeMinute;
    public int timeModifier;

    public bool isGamePaused;

    public Text NPCHintUIText;
    public Text ItemHintUIText;

    public GameObject currentControllingPlayer;
    public Animator currentControllingPlayerConversationModeCharacter;

    //0215: increase by observing clues, answering a question right & use for getting gift hints
    public int playerCandyCount = 20;

    public static GameManager instance;

    public List<GameObject> loop1UnlockDoors;
    public List<GameObject> loop1ResetGifts;

    public GameObject loop1Tutorial;
    public GameObject classroomDoor;
    public GameObject plum;
    
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
        #if UNITY_EDITOR

        #else
            SceneManager.LoadScene("Test_Art_OnlyLevel", LoadSceneMode.Additive);
        #endif

    }

    // Start is called before the first frame update
    void Start()
    {
        UIManager.instance.UIInitialize();
    }

    // Update is called once per frame
    void Update()
    {
        //NPCHintUIText.text = "NPC Hints Collected" + "\n" + Player.npcHintCollect + " / " + Player.npcHintTotal;
        //ItemHintUIText.text = "Item Hints Collected" + "\n" + Player.itemHintCollect + " / " + Player.itemHintTotal;

        // unlock when escape is hit
        if (Input.GetKeyDown(KeyCode.B) || Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }

        if(!NPCManager.instance.isHavingConversation)
        {
            currentLoopTimeFloat = Time.deltaTime + currentLoopTimeFloat;
            currentLoopTimeSecond = Mathf.RoundToInt(currentLoopTimeFloat);
            if (currentLoopTimeSecond >= 60 / timeModifier)
            {
                currentLoopTimeMinute++;
                currentLoopTimeSecond = 0;
                currentLoopTimeFloat = 0;
                Loop1.instance.oneTimeEventFlag = true;
                foreach (var npc in NPCManager.instance.NPCs)
                {
                    npc.GetComponent<NPC>().shouldMoveThisEvent = true;
                }
                if (currentLoopTimeMinute < 10)
                {
                    UIManager.instance.txt_Minute1.text = "0";
                    UIManager.instance.txt_Minute2.text = currentLoopTimeMinute.ToString();
                }
                else
                {
                    int minuteTenthDigit = currentLoopTimeMinute / 10;
                    int minuteOneDigit = currentLoopTimeMinute - 10 * minuteTenthDigit;
            
                    UIManager.instance.txt_Minute1.text = minuteTenthDigit.ToString();
                    UIManager.instance.txt_Minute2.text = minuteOneDigit.ToString();
                }

                if (ExitClassroomController.instance.isPlayerOutsideTheClassroom)
                {
                    ExitClassroomController.instance.playerOutTimeLong++;
                }
            }
        }
    }

    public void EnterConversationMode()
    {
        NPCManager.instance.isHavingConversation = true;
        currentControllingPlayer.GetComponent<MouseLook>().sensitivityX = 0;
        currentControllingPlayer.transform.GetChild(0).gameObject.GetComponent<MouseLook>().sensitivityY = 0;
        currentControllingPlayer.transform.GetChild(0).gameObject.GetComponent<LockMouse>().LockCursor(false);
    }

    public void ExitConversationMode()
    {
        currentControllingPlayer.GetComponent<MouseLook>().sensitivityX = 8;
        currentControllingPlayer.transform.GetChild(0).gameObject.GetComponent<MouseLook>().sensitivityY = 8;
        currentControllingPlayer.transform.GetChild(0).gameObject.GetComponent<LockMouse>().LockCursor(true);
        NPCManager.instance.isHavingConversation = false;
    }
    //this method is used when player is having a conversation with a NPC
    public void InConversation()
    {

    }

    public void Pause()
    {
        isGamePaused = !isGamePaused;
        if (NPCManager.instance.isHavingConversation)
        {
            if (isGamePaused)
            {
                //UIManager.instance.pausePanel.SetActive(true);
                UIManager.instance.MainSceneUI.SetActive(false);
                UIManager.instance.ViewPausePanel3D.SetActive(true);
                UIManager.instance.isDrawBookOpen = false;
                UIManager.instance.DisableFungusDialogInPausePanel3D();
                currentControllingPlayer.transform.GetChild(0).gameObject.GetComponent<LockMouse>().LockCursor(false);
            }
            else
            {
                //UIManager.instance.pausePanel.SetActive(false);
                //UIManager.instance.drawBookPanel.SetActive(false);
                //UIManager.instance.isDrawBookOpen = false;
                UIManager.instance.MainSceneUI.SetActive(true);
                UIManager.instance.ViewPausePanel3D.SetActive(false);
                UIManager.instance.drawBookPanel.SetActive(false);
                UIManager.instance.EnableFungusDialogInPausePanel3D();
            }
        }
        else
        {
            if (isGamePaused)
            {
                //EnterConversationMode();
                currentControllingPlayer.GetComponent<MouseLook>().sensitivityX = 0;
                currentControllingPlayer.transform.GetChild(0).gameObject.GetComponent<MouseLook>().sensitivityY = 0;
                currentControllingPlayer.transform.GetChild(0).gameObject.GetComponent<LockMouse>().LockCursor(false);
                //UIManager.instance.pausePanel.SetActive(true);
                UIManager.instance.MainSceneUI.SetActive(false);
                UIManager.instance.ViewPausePanel3D.SetActive(true);
                UIManager.instance.isDrawBookOpen = false;
                currentControllingPlayer.GetComponent<FirstPersonDrifter>().speed = 0;
            }
            else
            {
                //ExitConversationMode();
                currentControllingPlayer.GetComponent<MouseLook>().sensitivityX = 8;
                currentControllingPlayer.transform.GetChild(0).gameObject.GetComponent<MouseLook>().sensitivityY = 8;
                currentControllingPlayer.transform.GetChild(0).gameObject.GetComponent<LockMouse>().LockCursor(true);
                //UIManager.instance.pausePanel.SetActive(false);
                //UIManager.instance.drawBookPanel.SetActive(false);
                //UIManager.instance.isDrawBookOpen = false;
                UIManager.instance.MainSceneUI.SetActive(true);
                UIManager.instance.ViewPausePanel3D.SetActive(false);
                UIManager.instance.drawBookPanel.SetActive(false);
                currentControllingPlayer.GetComponent<FirstPersonDrifter>().speed = 6;
            }
        }
    }

    public void IncreaseTime(int timeCost)
    {
        currentLoopTimeMinute += timeCost;
        if (currentLoopTimeMinute < 10)
        {
            //UIManager.instance.txt_Time.text = "4:0" + currentLoopTimeMinute;
            UIManager.instance.txt_Minute1.text = "0";
            UIManager.instance.txt_Minute2.text = currentLoopTimeMinute.ToString();
        }
        else
        {
            //UIManager.instance.txt_Time.text = "4:" + currentLoopTimeMinute;

            int minuteTenthDigit = currentLoopTimeMinute / 10;
            int minuteOneDigit = currentLoopTimeMinute - 10 * minuteTenthDigit;
            
            UIManager.instance.txt_Minute1.text = minuteTenthDigit.ToString();
            UIManager.instance.txt_Minute2.text = minuteOneDigit.ToString();
        }
    }

    public void IncreaseCandy(int candyCount)
    {
        playerCandyCount += candyCount;
        UIManager.instance.UpdateCandyCount();
        VFXManager.instance.vfx_CandyGet.Play();
    }

    public void LoopReset()
    {
        foreach (var door in loop1UnlockDoors)
        {
            door.SetActive(false);
        }

        foreach (var gift in loop1ResetGifts)
        {
            gift.SetActive(true);
            gift.GetComponent<GiftItem>().observationLines.SetBooleanVariable("CanBeCollected",false);
            gift.GetComponent<GiftItem>().canBeCollected = false;
        }

        foreach (var child in NPCManager.instance.NPCs)
        {
            if (child.GetComponent<NPC>().childSeat != null)
            {
                child.transform.position = child.GetComponent<NPC>().childSeat.position;
            }
        }
        
        //unlock storyline title in drawbook
        UIManager.instance.drawbookStories[0].drawbookStoryPages[0].
            GetComponent<DrawBookPage>().clueGroupsInThisPage[1].titleRevealed.SetActive(true);
        UIManager.instance.drawbookStories[0].drawbookStoryPages[0].
            GetComponent<DrawBookPage>().clueGroupsInThisPage[1].titleUnRevealed.SetActive(false);
        
        //debug use only
        //disable loop0 flora dialog branch for loop1
        NPCManager.instance.NPCs[1].GetComponent<NPC>().flowchat.SetBooleanVariable("isSecondTimeAskLove",false);
        NPCManager.instance.NPCs[1].GetComponent<NPC>().flowchat.SetBooleanVariable("isFirstTimeAskLove",false);
        
        //something other reset unsorted
        currentControllingPlayer.transform.GetChild(0).gameObject.SetActive(true);
        loop1Tutorial.SetActive(true);
        plum.GetComponent<CharacterController>().enabled = true;
        classroomDoor.SetActive(true);
        
        Debug.Log("Loop Reset!");

    }
}
