using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * control all the NPCs behavior
 * 
 * currently achieved: Navigation(to be optimized), NPCHints, 
 * TODO: Events
 * 
 */

public class NPCManager : MonoBehaviour
{
    public static NPCManager instance;

    //like hints, should be replaced by scriptable objects or dictionary
    public List<GameObject> NPCs;
    public List<bool> isHintCollected;

    public bool isHavingConversation;

    public List<Transform> Cole_wayPoints;
    public List<Transform> Vick_wayPoints;
    public List<Transform> Flore_wayPoints;
    public List<Transform> Emi_wayPoints;

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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //used when player gets a hint from a NPC
    public void UpdateCollectedHints()
    {
        for (int i = 0; i < isHintCollected.Count; i++)
        {
            isHintCollected[i] = NPCs[i].GetComponent<NPC>().isCollected;
        }
    }

    //new NPC will be generated during a loop, so these two methods are used to update the NPC List
    public void AddNewNPC(GameObject thisNPC)
    {
        NPCs.Add(thisNPC);
        isHintCollected.Add(false);
    }

    public void DeleteCurrentNPC(GameObject thisNPC)
    {
        for (int i = 0; i < NPCs.Count; i++)
        {
            if(NPCs[i] == thisNPC)
            {
                NPCs.Remove(thisNPC);
                isHintCollected.Remove(isHintCollected[i]);
                break;
            }
        }

    }

    public void SetWayPointsByEvent(GameObject Event)
    {
        int wayPointsNum;
        for(int j = 0; j < NPCs.Count - 1; j++)
        {
            //Debug.Log("j = " + j);
            wayPointsNum = Event.transform.GetChild(j).childCount;
            //Debug.Log("NPC " + NPCs[j].name + " has" + wayPointsNum + " waypoints");
            for (int i = 0; i < wayPointsNum; i++)
            {
                NPCs[j].GetComponent<NPC>().wayPoints.Add(Event.transform.GetChild(j).GetChild(i));
            }
        }
    }
}
