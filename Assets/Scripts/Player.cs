﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float interactDistance;
    public float eavesdropDistance;

    public static int npcHintCollect = 0;
    public static int npcHintTotal = 6;
    
    public static int itemHintCollect = 0;
    public static int itemHintTotal = 4;

    public Transform chairPosition;
    private Transform cameraTransform;
    private GameObject currentGameobject;
    private RaycastHit hit;

    public GameObject pointingObject;

    private GameObject eavesdropCharacter;
    public GameObject eavesdropingObject;
    public bool isEavesdroping;

    public GameObject playerIcon;

    public int playerIndex;
    // Start is called before the first frame update
    void Start()
    {
        //Yanxi: Make the start PC (Jamie) able to see right objects.
        HintManager.instance.RefreshHintWhenSwitchingPlayer(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        //use raycast method to achieve player interaction with different objects
        if (Camera.main != null)
        {
            cameraTransform = Camera.main.transform;
        }

        Ray ray = new Ray(cameraTransform.position, cameraTransform.forward);
        if (Physics.Raycast(ray, out hit, interactDistance))
        {
            if (hit.collider != null)
            {
                currentGameobject = hit.collider.gameObject;
                //three types of interaction: Hints, Characters(Parents, Kids, Teachers), Players
                //0201: add new type of interaction 'move'
                //define by tag
                if (currentGameobject.tag == "move")
                {
                    //pointingObject = currentGameobject;
                    //when player collect a collectable item
                    UIManager.instance.crosshair.SetActive(false);
                    UIManager.instance.moveIcon.SetActive(true);
                    Tutorials.instance.SwitchAnotherPic(Tutorials.instance.pic8_Move);
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        Debug.Log("move something");
                        //currentGameobject.GetComponent<Hint>().OnObserve();
                    }
                }
                if (currentGameobject.tag == "hint")
                {
                    //pointingObject = currentGameobject;
                    //when player collect a collectable item
                    UIManager.instance.crosshair.SetActive(false);
                    UIManager.instance.observeIcon.SetActive(true);
                    Tutorials.instance.SwitchAnotherPic(Tutorials.instance.pic2_Observe);
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        currentGameobject.GetComponent<Hint>().OnObserve(gameObject);
                    }
                }
                if (currentGameobject.tag == "player")
                {
                    //pointingObject = currentGameobject;
                    //when player try to switch to another player character
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        SwitchPlayer(currentGameobject);
                        Tutorials.instance.SwitchAnotherPic(Tutorials.instance.pic7_Switch);
                    }
                }
                if (currentGameobject.tag == "character")
                {
                    isWithinTalkDistance(currentGameobject);
                    //Debug.Log("detect talkable player");
                    if(currentGameobject.GetComponent<NPC>().isWithInTalkDistance)
                    {
                        //Debug.Log("can talk");
                        //pointingObject = currentGameobject;
                        currentGameobject.GetComponent<NPC>().talkIcon.SetActive(true);
                        Tutorials.instance.SwitchAnotherPic(Tutorials.instance.pic1_Talk);
                        //when player start a conversation with a NPC
                        if (Input.GetKeyDown(KeyCode.E))
                        {
                            currentGameobject.GetComponent<NPC>().OnInteract(gameObject);
                            isEavesdroping = false;
                        }
                    }
                }
                if (currentGameobject.tag == "frontClassroomDoor")
                {
                    //pointingObject = currentGameobject;
                    //when player tries to open a door
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        ExitClassroomController.instance.playerInteractWithTheClassroomDoor();
                    }
                }
                if (currentGameobject.tag == "backClassroomDoor")
                {
                    //pointingObject = currentGameobject;
                    //when player tries to open a door
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        currentGameobject.GetComponent<OneWayDoor>().playerInteractWithTheClassroomDoor();
                    }
                }
                if (currentGameobject.tag == "commonConversationShort")
                {
                    //pointingObject = currentGameobject;
                    currentGameobject.GetComponent<CommonConversation>().chatIcon.SetActive(true);
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        Debug.Log("join");
                        currentGameobject.GetComponent<CommonConversation>().OnInteract();
                        Tutorials.instance.SwitchAnotherPic(Tutorials.instance.pic4_Listen);
                    }
                }
            }
            //else
            //{
            //    Debug.Log("hit nothing");
            //    currentGameobject = null;
            //}
            ////draw line only when the ray hit something
            //Debug.DrawLine(ray.origin, hit.point, Color.red);
        }
        else
        {
            //Debug.Log("hit nothing");
            currentGameobject = null;
            Debug.DrawLine(ray.origin, hit.point, Color.red);
        }

        if (currentGameobject != pointingObject)
        {
            if (pointingObject == null)
            {
                pointingObject = currentGameobject;
            }
            Debug.Log("clear icon");
            ClearIcon(pointingObject);
            pointingObject = currentGameobject;
        }

        if(Physics.Raycast(ray, out hit, eavesdropDistance))
        {
            if(hit.collider != null)
            {
                if (hit.collider.gameObject.tag == "character" && hit.collider.gameObject.GetComponent<NPC>().canBeEavesdroped)
                {
                    eavesdropCharacter = hit.collider.gameObject;
                    isWithinTalkDistance(eavesdropCharacter);
                    if (!eavesdropCharacter.GetComponent<NPC>().isWithInTalkDistance)
                    {
                        //eavesdropingObject = eavesdropCharacter;
                        eavesdropCharacter.GetComponent<NPC>().eavesdropIcon.SetActive(true);
                        if (Input.GetKeyDown(KeyCode.E))
                        {
                            Debug.Log("eavesdrop");
                            isEavesdroping = true;
                            eavesdropCharacter.GetComponent<NPC>().OnInteract(gameObject);
                        }
                    }
                    else
                    {
                        eavesdropCharacter = null;
                    }
                }

                if (hit.collider.gameObject.tag == "commonConversationLong")
                {
                    eavesdropCharacter = hit.collider.gameObject;
                    eavesdropCharacter.GetComponent<CommonConversation>().chatIcon.SetActive(true);
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        Debug.Log("eavesdrop");
                        eavesdropCharacter.GetComponent<CommonConversation>().OnInteract();
                    }
                }
            }
        }
        else
        {
            eavesdropCharacter = null;
        }

        if (eavesdropCharacter != eavesdropingObject)
        {
            if (eavesdropingObject == null)
            {
                eavesdropingObject = eavesdropCharacter;
            }
            ClearIcon(eavesdropingObject);
            eavesdropingObject = eavesdropCharacter;
        }
    }

    //stupid way to achieve switch character design
    public void SwitchPlayer(GameObject targetPlayer)
    {
        //enable component and camera on the one you want to switch 
        targetPlayer.GetComponent<FirstPersonDrifter>().enabled = true;
        targetPlayer.GetComponent<MouseLook>().enabled = true;
        targetPlayer.GetComponent<Player>().enabled = true;
        targetPlayer.GetComponent<Player>().playerIcon.SetActive(true);
        targetPlayer.GetComponent<Footsteps>().enabled = true;
        targetPlayer.GetComponent<AudioSource>().enabled = true;
        targetPlayer.GetComponent<UncontrolledPlayerFacing>().enabled = false;
        targetPlayer.transform.GetChild(0).gameObject.SetActive(true);

        //disable component and camera on the one you are controlling right now
        gameObject.GetComponent<FirstPersonDrifter>().enabled = false;
        gameObject.GetComponent<MouseLook>().enabled = false;
        gameObject.GetComponent<Player>().enabled = false;
        gameObject.GetComponent<Player>().playerIcon.SetActive(false);
        gameObject.GetComponent<Footsteps>().enabled = false;
        gameObject.GetComponent<AudioSource>().enabled = false;
        gameObject.GetComponent<UncontrolledPlayerFacing>().enabled = true;
        gameObject.transform.GetChild(0).gameObject.SetActive(false);

        //transport the one you are controlling to their seat
        GameManager.instance.currentControllingPlayer = targetPlayer;
        gameObject.transform.position = chairPosition.position;
        HintManager.instance.RefreshHintWhenSwitchingPlayer(targetPlayer);
        Debug.Log(targetPlayer.name);

        //TODO: make the transition more elegent (add some animation or using the cinemation?)
        //Nate: I think the transition now could make player feel a little bit confused perhaps for the camera position
    }

    public void ClearIcon(GameObject objectToBeCleared)
    {
        if(objectToBeCleared.tag == "character")
        {
            objectToBeCleared.GetComponent<NPC>().talkIcon.SetActive(false);
            objectToBeCleared.GetComponent<NPC>().eavesdropIcon.SetActive(false);
        }
        if(objectToBeCleared.tag == "hint")
        {
            UIManager.instance.crosshair.SetActive(true);
            UIManager.instance.observeIcon.SetActive(false);
        }
        if (objectToBeCleared.tag == "commonConversationShort")
        {
            objectToBeCleared.GetComponent<CommonConversation>().chatIcon.SetActive(false);
        }
        if (objectToBeCleared.tag == "commonConversationLong")
        {
            objectToBeCleared.GetComponent<CommonConversation>().chatIcon.SetActive(false);
        }
    }

    public void isWithinTalkDistance(GameObject NPC)
    {
        if(Vector3.Distance(NPC.transform.position, gameObject.transform.position) <= 3)
        {
            NPC.GetComponent<NPC>().isWithInTalkDistance = true;
        }
        else
        {
            NPC.GetComponent<NPC>().isWithInTalkDistance = false;
        }
    }
}
