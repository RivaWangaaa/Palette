using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loop1 : MonoBehaviour
{

    public bool oneTimeEventFlag = true;

    [Header("Event")] 
    public GameObject event455;
    public GameObject event450;
    public GameObject event446;
    public GameObject event443;
    public GameObject event440;
    public GameObject event436;
    public GameObject event430;
    public GameObject event429;
    public GameObject event424;
    public GameObject event413;
    public GameObject event410;
    public GameObject event400;
    public GameObject eventStart;
    public GameObject specialEvent2;
    public GameObject specialEvent1;

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
    public Sprite vickMom;
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
            //Yanxi: To start the start event at 4:00
            eventStart.transform.GetChild(4).gameObject.SetActive(true);
            
            NPCManager.instance.SetWayPointsByEvent(event400);
            oneTimeEventFlag = false;
            Debug.Log("Cole, Emi, Vick, Flora get together");
        }
        if (GameManager.instance.currentLoopTimeMinute == 4 && oneTimeEventFlag)
        {
            //Yanxi: To end the start event at 4:04
            eventStart.transform.GetChild(4).gameObject.SetActive(false);
            
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
        
        //Yanxi: changed 7 to 8
        if (GameManager.instance.currentLoopTimeMinute == 8 && oneTimeEventFlag)
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
            vick.canBeEavesdroped = true;
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
            vick.canBeEavesdroped = false;
            vick.pose.sprite = vickOriginalPose;
            ExitClassroomController.instance.oneKidComesBackTheRoom();
            oneTimeEventFlag = false;
        }
        //Yanxi
        /*
        if (GameManager.instance.currentLoopTimeMinute == 16 && oneTimeEventFlag)
        {
            Debug.Log("Vick is playing in the corner, can be eavesdrop, Vick is happy");
            vick.pose.sprite = vickPlaying;
            vick.canBeEavesdroped = true;
            vick.flowchat.SetBooleanVariable("IsPlaying", true);
            oneTimeEventFlag = false;
        }
        */
        
        //Yanxi
        if (GameManager.instance.currentLoopTimeMinute == 14 && oneTimeEventFlag)
        {
            Debug.Log("Vick arrives at his seat. Vick is happy");
            vick.flowchat.SetBooleanVariable("IsEavesdropping", true);
            vick.flowchat.SetBooleanVariable("IsHappy", true);
            oneTimeEventFlag = false;
        }
        
        //Yanxi
        if (GameManager.instance.currentLoopTimeMinute == 18 && oneTimeEventFlag)
        {
            Debug.Log("Vick backs to normal");
            vick.flowchat.SetBooleanVariable("IsHappy", false);
            oneTimeEventFlag = false;
        }
        
        //Yanxi
        /*
        if (GameManager.instance.currentLoopTimeMinute == 19 && oneTimeEventFlag)
        {
            Debug.Log("Vick is sad");
            vick.pose.sprite = vickSad;
            vick.canBeEavesdroped = false;
            vick.flowchat.SetBooleanVariable("IsPlaying", false);
            vick.flowchat.SetBooleanVariable("BeingSad", true);
            oneTimeEventFlag = false;
        }
        */
        
        //Yanxi
        if (GameManager.instance.currentLoopTimeMinute == 19 && oneTimeEventFlag)
        {
            Debug.Log("Vick is sad");
            vick.pose.sprite = vickSad;
            vick.flowchat.SetBooleanVariable("BeingSad", true);
            oneTimeEventFlag = false;
        }
        
        //Yanxi
        /*
        if (GameManager.instance.currentLoopTimeMinute == 21 && oneTimeEventFlag)
        {
            Debug.Log("Vick is not sad, Vick playhouse");
            vick.pose.sprite = vickPlaying;
            vick.flowchat.SetBooleanVariable("IsPlaying", true);
            vick.flowchat.SetBooleanVariable("BeingSad", false);
            oneTimeEventFlag = false;
        }
        */
       
        //Yanxi
        if (GameManager.instance.currentLoopTimeMinute == 23 && oneTimeEventFlag)
        {
            Debug.Log("Vick is not sad");
            vick.pose.sprite = vickOriginalPose;
            vick.flowchat.SetBooleanVariable("BeingSad", false);
            oneTimeEventFlag = false;
        }
        
        if (GameManager.instance.currentLoopTimeMinute == 24 && oneTimeEventFlag)
        {
            Debug.Log("Vick go to Flora");
            NPCManager.instance.SetWayPointsByEvent(event424);
            //(Disabled by Yanxi) vick.pose.sprite = vickOriginalPose;
            oneTimeEventFlag = false;
        }
        if (GameManager.instance.currentLoopTimeMinute == 25 && oneTimeEventFlag)
        {
            Debug.Log("Vick ask Flora how to be smarter");
            //Yanxi: vick and flora conversation set active
            //vick.flowchat.SetBooleanVariable("IsEavesdropping", true);
            //vick and flora conversation set active
            event424.transform.GetChild(4).gameObject.SetActive(true);
            oneTimeEventFlag = false;
        }
        //Yanxi
        if (GameManager.instance.currentLoopTimeMinute == 28 && oneTimeEventFlag)
        {
            Debug.Log("Vick stops asking Flora");
            event424.transform.GetChild(4).gameObject.SetActive(false);
            oneTimeEventFlag = false;
        }
        
        if (GameManager.instance.currentLoopTimeMinute == 30 && oneTimeEventFlag)
        {
            Debug.Log("Flora goes to toilet");
            NPCManager.instance.SetWayPointsByEvent(event429);
            ExitClassroomController.instance.oneKidExitsTheRoom();
            oneTimeEventFlag = false;
            
            //Yanxi: added Vick goes to play house
            Debug.Log("Vick goes to play house");
            NPCManager.instance.SetWayPointsByEvent(event430);
            vick.pose.sprite = vickPlaying;
            vick.flowchat.SetBooleanVariable("IsPlaying", true);
        }
        
        if (GameManager.instance.currentLoopTimeMinute == 36 && oneTimeEventFlag)
        {
            Debug.Log("Flora comes back");
            NPCManager.instance.SetWayPointsByEvent(event436);
            ExitClassroomController.instance.oneKidComesBackTheRoom();
            oneTimeEventFlag = false;
        }
        if (GameManager.instance.currentLoopTimeMinute == 37 && oneTimeEventFlag)
        {
            Debug.Log("Flora confront with teacher, Vick is happy");
            event436.transform.GetChild(4).gameObject.SetActive(true);
            // Yanxi: changed smiling to freaking;
            flora.pose.sprite = floraFreaking;
            // (Disabled by Yanxi) vick.pose.sprite = vickPlaying;
            oneTimeEventFlag = false;
        }

        if (GameManager.instance.currentLoopTimeMinute == 40 && oneTimeEventFlag)
        { 
            Debug.Log("Flora and Vick come back to the seat");
            event436.transform.GetChild(4).gameObject.SetActive(false);
            NPCManager.instance.SetWayPointsByEvent(event440); 
            //flora.pose.sprite = floraOriginalPose;
            //Yanxi: don't know why Vick won't change to original pose.  
            vick.pose.sprite = vickOriginalPose;
            oneTimeEventFlag = false;
        }
        if (GameManager.instance.currentLoopTimeMinute == 43 && oneTimeEventFlag)
        {
            Debug.Log("Flora and Vick go away");
            //Yanxi
            flora.pose.sprite = floraOriginalPose;
            vick.pose.sprite = vickOriginalPose;
            
            NPCManager.instance.SetWayPointsByEvent(event443);
            oneTimeEventFlag = false;
        }
        if (GameManager.instance.currentLoopTimeMinute == 44 && oneTimeEventFlag)
        {
            Debug.Log("Flora talk to Vick");
            event443.transform.GetChild(4).gameObject.SetActive(true);
            oneTimeEventFlag = false;
        }
        
        //Yanxi: changed 46 to 47
        if (GameManager.instance.currentLoopTimeMinute == 47 && oneTimeEventFlag)
        {
            Debug.Log("Flora and Vick keep going");
            //Yanxi
            event443.transform.GetChild(4).gameObject.SetActive(false);
            
            NPCManager.instance.SetWayPointsByEvent(event446);
            oneTimeEventFlag = false;
        }
        
        //Yanxi: changed 50 to 53
        if (GameManager.instance.currentLoopTimeMinute == 53 && oneTimeEventFlag)
        {
            Debug.Log("Vick mom comes to the classroom, use Emi for temp");
            NPCManager.instance.SetWayPointsByEvent(event450);
            emi.pose.sprite = vickMom;
            oneTimeEventFlag = false;
        }
        if (GameManager.instance.currentLoopTimeMinute == 55 && oneTimeEventFlag)
        {
            Debug.Log("Vick mom leaves the classroom");
            NPCManager.instance.SetWayPointsByEvent(event455);
            oneTimeEventFlag = false;
        }
        
        //Thursday Showcase
        if (GameManager.instance.currentLoopTimeMinute == 65 && oneTimeEventFlag)
        {
            Debug.Log("Event1: Vick walk to teacher");
            NPCManager.instance.NPCs[4].GetComponent<NPC>().shouldMoveThisEvent = false;
            NPCManager.instance.SetWayPointsByEvent(specialEvent1);
            oneTimeEventFlag = false;
        }
        if (GameManager.instance.currentLoopTimeMinute == 67 && oneTimeEventFlag)
        {
            Debug.Log("Event1: Vick talk to teacher about note system");
            specialEvent1.transform.GetChild(4).gameObject.SetActive(true);
            oneTimeEventFlag = false;
        }

        if (GameManager.instance.currentLoopTimeMinute == 70 && oneTimeEventFlag)
        {
            Debug.Log("Event2: Flora walk to outside");
            NPCManager.instance.SetWayPointsByEvent(specialEvent2);
            oneTimeEventFlag = false;
        }
        
    }
}
