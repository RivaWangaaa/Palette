using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintManager : MonoBehaviour
{
    public static HintManager instance;

    public int stickerCounts;

    public int pitCluesCounts;
    //this should be replaced with Dictionary in the future
    public List<GameObject> observableObject;
    public List<bool> isHintCollected;

    public List<GiftItem> giftObjects;

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

    private void Start()
    {
        //auto generate a bool for each item
        //Nate: again this is because I could not use dictionary or scriptable object
        for (int i = 0; i < observableObject.Count; i++)
        {
            isHintCollected.Add(false);
        }
    }


}
