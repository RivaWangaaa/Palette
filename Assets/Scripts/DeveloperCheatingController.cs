using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeveloperCheatingController : MonoBehaviour
{
    public GameObject classroomDoorCollider;
    public GameObject classroomDoorBackCollider;
    private bool isClassroomDoorColliderEnabled;
    public Transform toyroomTP;
    public Transform classroomTP;
    public Transform naproomTP;
    public Transform hallwayTP;
    
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

        if (Input.GetKeyDown(KeyCode.G))
        {
            SceneManager.LoadScene(0);
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
