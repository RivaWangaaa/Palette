using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Fungus;

public class DeveloperCheatingController : MonoBehaviour
{
    public GameObject classroomDoorCollider;
    public GameObject classroomDoorBackCollider;
    private bool isClassroomDoorColliderEnabled;
    public Transform toyroomTP;
    public Transform classroomTP;
    public Transform naproomTP;
    public Transform hallwayTP;

    public Flowchart floraFlowchart;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            LoopReset();
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            Transport(toyroomTP.position);
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            Transport(classroomTP.position);
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            Transport(naproomTP.position);
        }
        if(Input.GetKeyDown((KeyCode.H)))
        {
            Transport(hallwayTP.position);
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            DisableEnableClassroomDoor();
        }
        
        //审问flora
        if(Input.GetKeyDown(KeyCode.Y))
        {
            FlowchartVariablesManager.instance.GetComponent<Flowchart>().SetBooleanVariable("Loop1isJewelBelongFloraFound",true);
        }
        //获得礼物
        if(Input.GetKeyDown(KeyCode.U))
        {
            NPCManager.instance.NPCIsNotAngry(NPCManager.instance.NPCs[1].gameObject,
                "FloraIsAngry","isHaveGift");
            Debug.Log(NPCManager.instance.NPCs[1].gameObject.name);
        }
    }

    public void Transport(Vector3 position)
    {
        GameManager.instance.currentControllingPlayer.GetComponent<CharacterController>().enabled = false;
        GameManager.instance.currentControllingPlayer.transform.position = position;
        GameManager.instance.currentControllingPlayer.GetComponent<CharacterController>().enabled = true;
    }

    public void DisableEnableClassroomDoor()
    {
        if (isClassroomDoorColliderEnabled)
        {
            classroomDoorCollider.SetActive(false);
            isClassroomDoorColliderEnabled = false;
            classroomDoorBackCollider.SetActive(false);
            Debug.Log("doors collider disabled!");
        }
        else
        {
            classroomDoorBackCollider.SetActive(true);
            classroomDoorCollider.SetActive(true);
            isClassroomDoorColliderEnabled = true;
            Debug.Log("doors collider enabled!");
        }
    }

    public void LoopReset()
    {
        GameManager.instance.LoopReset();
        
        //disable loop0 flora dialog branch for loop1
        FlowchartVariablesManager.instance.GetComponent<Flowchart>().SetBooleanVariable("Loop0isSecondTimeAskLove",false);
        FlowchartVariablesManager.instance.GetComponent<Flowchart>().SetBooleanVariable("Loop0isFirstTimeAskLove",false);
        //enable go out classroom function
        FlowchartVariablesManager.instance.GetComponent<Flowchart>().SetBooleanVariable("AbleToGetOutClassroom",true);
    }
    
}
