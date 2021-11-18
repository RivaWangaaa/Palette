using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float distance;

    public static int npcHintCollect = 0;
    public static int npcHintTotal = 6;
    
    public static int itemHintCollect = 0;
    public static int itemHintTotal = 4;

    public Transform chairPosition;
    private Transform cameraTransform;
    private GameObject currentGameobject;
    private RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {
        
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
        if (Physics.Raycast(ray, out hit, distance))
        {
            if (hit.collider != null)
            {
                currentGameobject = hit.collider.gameObject;
                //three types of interaction: Hints, Characters(Parents, Kids, Teachers), Players
                //define by tag
                if (currentGameobject.tag == "hint")
                {
                    //when player collect a collectable item
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        currentGameobject.GetComponent<Hint>().OnCollected();
                    }
                }
                if (currentGameobject.tag == "player")
                {
                    //when player try to switch to another player character
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        SwitchPlayer(currentGameobject);
                    }
                }
                if (currentGameobject.tag == "character")
                {
                    //when player start a conversation with a NPC
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        currentGameobject.GetComponent<NPC>().OnInteract(gameObject);
                    }
                }
            }
            else
            {
                currentGameobject = null;
            }
            //draw line only when the ray hit something
            Debug.DrawLine(ray.origin, hit.point, Color.red);
        }

    }

    //stupid way to achieve switch character design
    public void SwitchPlayer(GameObject targetPlayer)
    {
        //enable component and camera on the one you want to switch 
        targetPlayer.GetComponent<FirstPersonDrifter>().enabled = true;
        targetPlayer.GetComponent<MouseLook>().enabled = true;
        targetPlayer.GetComponent<Player>().enabled = true;
        targetPlayer.GetComponent<Footsteps>().enabled = true;
        targetPlayer.GetComponent<AudioSource>().enabled = true;
        targetPlayer.transform.GetChild(0).gameObject.SetActive(true);

        //disable component and camera on the one you are controlling right now
        gameObject.GetComponent<FirstPersonDrifter>().enabled = false;
        gameObject.GetComponent<MouseLook>().enabled = false;
        gameObject.GetComponent<Player>().enabled = false;
        gameObject.GetComponent<Footsteps>().enabled = false;
        gameObject.GetComponent<AudioSource>().enabled = false;
        gameObject.transform.GetChild(0).gameObject.SetActive(false);

        //transport the one you are controlling to their seat
        gameObject.transform.position = chairPosition.position;

        //TODO: make the transition more elegent (add some animation or using the cinemation?)
        //Nate: I think the transition now could make player feel a little bit confused perhaps for the camera position
    }

    public void SayHi()
    {
        Debug.Log("say hi");
    }
}
