using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loop1 : MonoBehaviour
{
    public Transform Cole_wayPoint4_00;
    public Transform Vick_wayPoint4_00;
    public Transform Flora_wayPoint4_00;


    private void Update()
    {
        if(GameManager.instance.currentLoopTimeMinute == 0)
        {
            Debug.Log("Cole, Emi, Vick, Flora get together");
            Event(3);
            NPCMove(NPCManager.instance.NPCs[0], true, null, Cole_wayPoint4_00);
            NPCMove(NPCManager.instance.NPCs[1], true, null, Vick_wayPoint4_00);
            NPCMove(NPCManager.instance.NPCs[2], true, null, Flora_wayPoint4_00);
        }
        if(GameManager.instance.currentLoopTimeMinute == 6)
        {
            Debug.Log("Vick check pocket, change character pose");
            //Event();
        }
    }

    public void Event(int consumeTime)
    {
        GameManager.instance.currentLoopTimeMinute += consumeTime;
    }

    public void NPCMove(GameObject NPC, bool isSingleMove,List<Transform> wayPoints, Transform waypoint)
    {
        if(isSingleMove)
        {
            NPC.GetComponent<NPC>().wayPoints.Add(waypoint);
        }
        else
        {
            NPC.GetComponent<NPC>().wayPoints = wayPoints;
        }
    }
}
