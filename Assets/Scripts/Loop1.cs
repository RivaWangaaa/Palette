using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loop1 : MonoBehaviour
{

    public bool oneTimeEventFlag = true;

    [Header("Event")]
    public GameObject Event410;
    public GameObject Event400;
    public GameObject EventStart;

    [Header("Vick Pose")]
    public Sprite vickStomache;
    public Sprite vickReachingPocketPose;
    public Sprite vickOriginalPose;

    [Header("Vick Pose")]
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
            NPCManager.instance.SetWayPointsByEvent(Event400);
            oneTimeEventFlag = false;
            Debug.Log("Cole, Emi, Vick, Flora get together");
        }
        if (GameManager.instance.currentLoopTimeMinute == 3 && oneTimeEventFlag)
        {
            NPCManager.instance.SetWayPointsByEvent(EventStart);
            oneTimeEventFlag = false;
            Debug.Log("Everyone Back to Their Seat");
        }
        if (GameManager.instance.currentLoopTimeMinute == 6 + ExitClassroomController.instance.playerOutTimeLong && oneTimeEventFlag)
        {
            Debug.Log("Vick check pocket, change character pose");
            vick.pose.sprite = vickReachingPocketPose;
            vick.flowchat.SetBooleanVariable("IsReachingPocket", true);
            oneTimeEventFlag = false;
        }
        if (GameManager.instance.currentLoopTimeMinute == 7 + ExitClassroomController.instance.playerOutTimeLong && oneTimeEventFlag)
        {
            Debug.Log("Vick back to normal");
            vick.pose.sprite = vickOriginalPose;
            vick.flowchat.SetBooleanVariable("IsReachingPocket", false);
            oneTimeEventFlag = false;
        }
        if(GameManager.instance.currentLoopTimeMinute == 10 + ExitClassroomController.instance.playerOutTimeLong && oneTimeEventFlag)
        {
            Debug.Log("Vick stomache, Flora smile");
            NPCManager.instance.SetWayPointsByEvent(Event410);
            vick.pose.sprite = vickStomache;
            vick.flowchat.SetBooleanVariable("IsStomaching", true);
            flora.pose.sprite = floraSmiling;
            oneTimeEventFlag = false;
        }
        if (GameManager.instance.currentLoopTimeMinute == 11 + ExitClassroomController.instance.playerOutTimeLong && oneTimeEventFlag)
        {
            Debug.Log("Vick is out, Flora stop smile");
            flora.pose.sprite = floraOriginalPose;
            ExitClassroomController.instance.oneKidExitsTheRoom();
            oneTimeEventFlag = false;
        }
    }
}
