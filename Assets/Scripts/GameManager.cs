using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public static GameManager instance;
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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //NPCHintUIText.text = "NPC Hints Collected" + "\n" + Player.npcHintCollect + " / " + Player.npcHintTotal;
        //ItemHintUIText.text = "Item Hints Collected" + "\n" + Player.itemHintCollect + " / " + Player.itemHintTotal;

        // unlock when escape is hit
        if (Input.GetKeyDown(KeyCode.P))
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
                if (currentLoopTimeMinute < 10)
                {
                    UIManager.instance.txt_Time.text = "4:0" + currentLoopTimeMinute;
                }
                else
                {
                    UIManager.instance.txt_Time.text = "4:" + currentLoopTimeMinute;
                }

                if (ExitClassroomController.instance.isPlayerOutsideTheClassroom)
                {
                    ExitClassroomController.instance.playerOutTimeLong++;
                }
            }
        }
    }

    //this method is used when player is having a conversation with a NPC
    public void InConversation()
    {

    }

    public void Pause()
    {
        isGamePaused = !isGamePaused;
        if (isGamePaused)
        {
            currentControllingPlayer.GetComponent<MouseLook>().sensitivityX = 0;
            currentControllingPlayer.transform.GetChild(0).gameObject.GetComponent<MouseLook>().sensitivityY = 0;
            currentControllingPlayer.transform.GetChild(0).gameObject.GetComponent<LockMouse>().LockCursor(false);
            currentControllingPlayer.GetComponent<FirstPersonDrifter>().speed = 0;
            UIManager.instance.pausePanel.SetActive(true);
            NPCManager.instance.isHavingConversation = true;
        }
        else
        {
            currentControllingPlayer.GetComponent<MouseLook>().sensitivityX = 8;
            currentControllingPlayer.transform.GetChild(0).gameObject.GetComponent<MouseLook>().sensitivityY = 8;
            currentControllingPlayer.transform.GetChild(0).gameObject.GetComponent<LockMouse>().LockCursor(true);
            currentControllingPlayer.GetComponent<FirstPersonDrifter>().speed = 6;
            UIManager.instance.pausePanel.SetActive(false);
            UIManager.instance.drawBookPanel.SetActive(false);
            UIManager.instance.isDrawBookOpen = false;
            NPCManager.instance.isHavingConversation = false;
        }
    }
}
