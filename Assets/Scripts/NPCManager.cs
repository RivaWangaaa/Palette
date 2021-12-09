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

    //Navigation system
    public float pk1Time;
    public float pk2Time;
    public float pk3Time;
    
    private float timer;

    public GameObject p1k1Manager;
    public GameObject pk2Manager;
    public GameObject pk3Manager;

    private P1K1 p1k1Script;
    private PK2 pk2Script;
    private PK3 pk3Script;
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
}
