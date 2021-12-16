using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loop1 : MonoBehaviour
{

    public bool oneTimeEventFlag = true;

    [Header("Event")] 
    public GameObject event446;
    public GameObject event443;
    public GameObject event440;
    public GameObject event436;
    public GameObject event429;
    public GameObject event424;
    public GameObject event413;
    public GameObject event410;
    public GameObject event400;
    public GameObject eventStart;

    [Header("Vick Pose")]
    public Sprite vickSad;
    public Sprite vickPlaying;
    public Sprite vickStomache;
    public Sprite vickReachingPocketPose;
    public Sprite vickOriginalPose;

    [Header("flora Pose")] 
    public Sprite floraFreaking;
    public Sprite floraSmiling;
    public Sprite floraOriginalPose;

    [Header("Emi Pose")]
    public Sprite emiOriginalPose;

    [Header("Cole Pose")]
    public Sprite coleOriginalPose;

    private NPC vick;
    private NPC flora;
    private NPC emi;
    private NPC cole;

    //public int eventDelay;

    public static Loop1 instance;
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

    private void Start()
    {
        cole = NPCManager.instance.NPCs[0].GetComponent<NPC>();
        flora = NPCManager.instance.NPCs[1].GetComponent<NPC>();
        vick = NPCManager.instance.NPCs[2].GetComponent<NPC>();
        emi = NPCManager.instance.NPCs[3].GetComponent<NPC>();

    }

    private void Update()
    {
        if(GameManager.instance.currentLoopTimeMinute == 0 && oneTimeEventFlag)
        {
            NPCManager.instance.SetWayPointsByEvent(event400);
            oneTimeEventFlag = false;
            Debug.Log("Cole, Emi, Vick, Flora get together");
        }
        if (GameManager.instance.currentLoopTimeMinute == 3 && oneTimeEventFlag)
        {
            NPCManager.instance.SetWayPointsByEvent(eventStart);
            oneTimeEventFlag = false;
            Debug.Log("Everyone Back to Their Seat");
        }
        if (GameManager.instance.currentLoopTimeMinute == 6 && oneTimeEventFlag)
        {
            Debug.Log("Vick check pocket, change character pose");
            vick.pose.sprite = vickReachingPocketPose;
            vick.flowchat.SetBooleanVariable("IsReachingPocket", true);
            oneTimeEventFlag = false;
        }
        if (GameManager.instance.currentLoopTimeMinute == 7 && oneTimeEventFlag)
        {
            Debug.Log("Vick back to normal");
            vick.pose.sprite = vickOriginalPose;
            vick.flowchat.SetBooleanVariable("IsReachingPocket", false);
            oneTimeEventFlag = false;
        }
        if(GameManager.instance.currentLoopTimeMinute == 10 && oneTimeEventFlag)
        {
            Debug.Log("Vick stomache, Flora smile");
            NPCManager.instance.SetWayPointsByEvent(event410);
            //Vick
            vick.pose.sprite = vickStomache;
            vick.flowchat.SetBooleanVariable("IsStomaching", true);
            //Flora
            flora.pose.sprite = floraSmiling;
            oneTimeEventFlag = false;
        }
        if (GameManager.instance.currentLoopTimeMinute == 11 && oneTimeEventFlag)
        {
            Debug.Log("Vick is out, Flora stop smile");
            flora.pose.sprite = floraOriginalPose;
            ExitClassroomController.instance.oneKidExitsTheRoom();
            oneTimeEventFlag = false;
        }
        if (GameManager.instance.currentLoopTimeMinute == 13 && oneTimeEventFlag)
        {
            Debug.Log("Vick is back");
            vick.flowchat.SetBooleanVariable("IsStomaching", false);
            NPCManager.instance.SetWayPointsByEvent(event413);
            vick.pose.sprite = vickOriginalPose;
            ExitClassroomController.instance.oneKidComesBackTheRoom();
            oneTimeEventFlag = false;
        }
        if (GameManager.instance.currentLoopTimeMinute == 16 && oneTimeEventFlag)
        {
            Debug.Log("Vick is playing in the corner, can be eavesdrop, Vick is happy");
            vick.pose.sprite = vickPlaying;
            vick.canBeEavesdroped = true;
            vick.flowchat.SetBooleanVariable("IsPlaying", true);
            oneTimeEventFlag = false;
        }
        if (GameManager.instance.currentLoopTimeMinute == 19 && oneTimeEventFlag)
        {
            Debug.Log("Vick is sad");
            vick.pose.sprite = vickSad;
            vick.canBeEavesdroped = false;
            vick.flowchat.SetBooleanVariable("IsPlaying", false);
            vick.flowchat.SetBooleanVariable("BeingSad", true);
            oneTimeEventFlag = false;
        }
        if (GameManager.instance.currentLoopTimeMinute == 21 && oneTimeEventFlag)
        {
            Debug.Log("Vick is not sad, playing house");
            vick.pose.sprite = vickPlaying;
            vick.flowchat.SetBooleanVariable("IsPlaying", true);
            vick.flowchat.SetBooleanVariable("BeingSad", false);
            oneTimeEventFlag = false;
        }
        if (GameManager.instance.currentLoopTimeMinute == 24 && oneTimeEventFlag)
        {
            Debug.Log("Vick go to Flora");
            NPCManager.instance.SetWayPointsByEvent(event424);
            vick.pose.sprite = vickOriginalPose;
            oneTimeEventFlag = false;
        }
        if (GameManager.instance.currentLoopTimeMinute == 25 && oneTimeEventFlag)
        {
            Debug.Log("Vick ask Flora how to be smarter");
            //vick and flora conversation set active
            event424.transform.GetChild(4).gameObject.SetActive(true);
            oneTimeEventFlag = false;
        }
        if (GameManager.instance.currentLoopTimeMinute == 30 && oneTimeEventFlag)
        {
            Debug.Log("Flora goes to toilet");
            NPCManager.instance.SetWayPointsByEvent(event429);
            ExitClassroomController.instance.oneKidExitsTheRoom();
            oneTimeEventFlag = false;
        }
        if (GameManager.instance.currentLoopTimeMinute == 36 && oneTimeEventFlag)
        {
            Debug.Log("Flora comes back, Vick goes and play");
            NPCManager.instance.SetWayPointsByEvent(event436);
            ExitClassroomController.instance.oneKidComesBackTheRoom();
            oneTimeEventFlag = false;
        }
        if (GameManager.instance.currentLoopTimeMinute == 37 && oneTimeEventFlag)
        {
            Debug.Log("Flora confront with teacher, Vick is happy");
            event436.transform.GetChild(4).gameObject.SetActive(true);
            flora.pose.sprite = floraSmiling;
            vick.pose.sprite = vickPlaying;
            oneTimeEventFlag = false;
        }
        if (GameManager.instance.currentLoopTimeMinute == 40 && oneTimeEventFlag)
        {
            Debug.Log("Flora and Vick come back to the seat");
            NPCManager.instance.SetWayPointsByEvent(event440);
            flora.pose.sprite = floraOriginalPose;
            vick.pose.sprite = vickOriginalPose;
            oneTimeEventFlag = false;
        }
        if (GameManager.instance.currentLoopTimeMinute == 43 && oneTimeEventFlag)
        {
            Debug.Log("Flora and Vick go away");
            NPCManager.instance.SetWayPointsByEvent(event443);
            oneTimeEventFlag = false;
        }
        if (GameManager.instance.currentLoopTimeMinute == 44 && oneTimeEventFlag)
        {
            Debug.Log("Flora talk to Vick");
            event443.transform.GetChild(4).gameObject.SetActive(true);
            oneTimeEventFlag = false;
        }
        if (GameManager.instance.currentLoopTimeMinute == 46 && oneTimeEventFlag)
        {
            Debug.Log("Flora and Vick keep going");
            NPCManager.instance.SetWayPointsByEvent(event446);
            oneTimeEventFlag = false;
        }
    }
}
