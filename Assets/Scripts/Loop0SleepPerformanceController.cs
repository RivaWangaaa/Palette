using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loop0SleepPerformanceController : MonoBehaviour
{
    public GameObject FallAsleepCam;
    public GameObject JumpScareCutScene;
    public GameObject levelDoor;
    
    public void Loop0EndBackToSeat()
    {
        GameManager.instance.currentControllingPlayer.GetComponent<CharacterController>().enabled = false;
        GameManager.instance.currentControllingPlayer.transform.position 
            = GameManager.instance.currentControllingPlayer.GetComponent<Player>().chairPosition.position;
        GameManager.instance.currentControllingPlayer.GetComponent<CharacterController>().enabled = true;
        FallAsleepCam.SetActive(true);
        GameManager.instance.currentControllingPlayer.transform.GetChild(0).gameObject.SetActive(false);
    }
    
    public void Loop0EndWakeUp()
    {
        FallAsleepCam.SetActive(false);
        GameManager.instance.currentControllingPlayer.transform.GetChild(0).gameObject.SetActive(true);
    }

    public void Loop0EndJumpScare()
    {
        //GameManager.instance.EnterConversationMode();
        levelDoor.SetActive(false);
        JumpScareCutScene.SetActive(true);
        gameObject.GetComponent<BoxCollider>().enabled = false;
        GameManager.instance.currentControllingPlayer.transform.GetChild(0).gameObject.SetActive(false);
        GameManager.instance.currentControllingPlayer.GetComponent<CharacterController>().enabled = false;
        GameManager.instance.currentControllingPlayer.transform.position 
            = GameManager.instance.currentControllingPlayer.GetComponent<Player>().chairPosition.position;
        GameManager.instance.currentControllingPlayer.GetComponent<CharacterController>().enabled = true;
    }

    public void Loop0EedJumpScareSetUp()
    {
        JumpScareCutScene.GetComponent<BoxCollider>().enabled = true;
    }
}
