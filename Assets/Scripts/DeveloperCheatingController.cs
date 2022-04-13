using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeveloperCheatingController : MonoBehaviour
{
    public GameObject classroomDoorCollider;
    public GameObject classroomDoorBackCollider;
    private bool isClassroomDoorColliderEnabled;
    public Transform toyroomTP;
    public Transform classroomTP;
    public Transform naproomTP;
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
        if (Input.GetKeyDown(KeyCode.F))
        {
            DisableEnableClassroomDoor();
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
    }
    
}
