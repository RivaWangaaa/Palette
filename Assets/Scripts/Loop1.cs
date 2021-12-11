using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loop1 : MonoBehaviour
{

    public bool oneTimeEventFlag = true;

    [Header("Event")]
    public GameObject Event400;
    public GameObject EventStart;

    [Header("Pose")]
    public Sprite vickReachingPocketPose;
    public Sprite vickOriginalPose;
    public Sprite floraOriginalPose;
    public Sprite emiOriginalPose;
    public Sprite coleOriginalPose;

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
        if (GameManager.instance.currentLoopTimeMinute == 6)
        {
            Debug.Log("Vick check pocket, change character pose");
            NPCManager.instance.NPCs[2].GetComponent<NPC>().pose.sprite = vickReachingPocketPose;
        }
        if (GameManager.instance.currentLoopTimeMinute == 7)
        {
            Debug.Log("Vick back");
            NPCManager.instance.NPCs[2].GetComponent<NPC>().pose.sprite = vickOriginalPose;
        }
    }
}
