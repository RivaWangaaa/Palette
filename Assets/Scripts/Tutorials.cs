using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorials : MonoBehaviour
{
    public static Tutorials instance;
    
    public GameObject pic1_Talk;
    public GameObject pic2_Observe;
    public GameObject pic3_Eavesdrop;
    public GameObject pic4_Listen;
    public GameObject pic5_Pause;
    public GameObject pic6_Drawbook;
    public GameObject pic7_Switch;
    public GameObject pic8_Move;

    public GameObject currentPic;

    public float eachPicTime = 3f;
    private float currentPicTime;
    private void Awake()
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

    private void Update()
    {
        if (currentPic != null && currentPicTime <= 3f)
        {
            currentPicTime += Time.deltaTime;
        }

        if (currentPicTime >= 3f)
        {
            currentPic.SetActive(false);
            Destroy(currentPic);
            currentPic = null;
            currentPicTime = 0;
        }
    }

    public void SwitchAnotherPic(GameObject incomingPic)
    {
        if (currentPic == null && incomingPic != null)
        {
            incomingPic.SetActive(true);
            currentPic = incomingPic;
        }
    }
}
