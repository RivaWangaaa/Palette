using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loop1 : MonoBehaviour
{
    public Transform Cole_wayPoint4_00;
    public Transform Vick_wayPoint4_00;
    public Transform Flora_wayPoint4_00;

    private bool oneTimeEventFlag = true;

    public GameObject Event400;


    private void Update()
    {
        if(GameManager.instance.currentLoopTimeMinute == 0 && oneTimeEventFlag)
        {
            NPCManager.instance.SetWayPointsByEvent(Event400);
            oneTimeEventFlag = false;
            Debug.Log("Cole, Emi, Vick, Flora get together");
        }
        if(GameManager.instance.currentLoopTimeMinute == 6)
        {
            Debug.Log("Vick check pocket, change character pose");
        }
    }
}
