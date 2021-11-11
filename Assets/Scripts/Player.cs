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
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        currentGameobject.GetComponent<Hint>().OnCollected();
                    }
                }
                if (currentGameobject.tag == "player")
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        SwitchPlayer(currentGameobject);
                    }
                }
                if (currentGameobject.tag == "character")
                {
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
            Debug.DrawLine(ray.origin, hit.point, Color.red);
        }

    }

    public void SwitchPlayer(GameObject targetPlayer)
    {
        targetPlayer.GetComponent<FirstPersonDrifter>().enabled = true;
        targetPlayer.GetComponent<MouseLook>().enabled = true;
        targetPlayer.GetComponent<Player>().enabled = true;
        targetPlayer.GetComponent<Footsteps>().enabled = true;
        targetPlayer.GetComponent<AudioSource>().enabled = true;
        targetPlayer.transform.GetChild(0).gameObject.SetActive(true);

        gameObject.GetComponent<FirstPersonDrifter>().enabled = false;
        gameObject.GetComponent<MouseLook>().enabled = false;
        gameObject.GetComponent<Player>().enabled = false;
        gameObject.GetComponent<Footsteps>().enabled = false;
        gameObject.GetComponent<AudioSource>().enabled = false;
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
        gameObject.transform.position = chairPosition.position;
    }
    
}
