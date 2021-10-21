using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCManager : MonoBehaviour
{
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
    
    // Start is called before the first frame update
    void Start()
    {
        p1k1Script = p1k1Manager.GetComponent<P1K1>();
        p1k1Script.enabled = false;
        
        pk2Script = pk2Manager.GetComponent<PK2>();
        pk2Script.enabled = false;
        
        pk3Script = pk3Manager.GetComponent<PK3>();
        pk3Script.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //timer
        timer += Time.deltaTime;

        if (timer >= pk1Time)
        {
            p1k1Script.enabled = true;
        }
        
        if (timer >= pk2Time)
        {
            pk2Script.enabled = true;
        }
        
        if (timer >= pk3Time)
        {
            pk3Script.enabled = true;
        }
    }
}
