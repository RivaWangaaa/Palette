using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCManager : MonoBehaviour
{
    private float timer;

    public GameObject p1k1Manager;

    private P1K1 p1k1Script;
    // Start is called before the first frame update
    void Start()
    {
        p1k1Script = p1k1Manager.GetComponent<P1K1>();
        p1k1Script.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //timer
        timer += Time.deltaTime;

        if (timer >= 30f)
        {
            p1k1Script.enabled = true;
        }
    }
}
