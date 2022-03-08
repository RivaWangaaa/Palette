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
    
    /*public void RefreshHintWhenSwitchingPlayer(GameObject player)
    {
        for(int i = 0; i < observableObject.Count; i++)
        {
            switch (player.GetComponent<Player>().playerIndex)
            {
                case 1:
                    if (observableObject[i].GetComponent<Hint>().canBeSeenByJimie)
                    {
                        observableObject[i].SetActive(true);
                    }
                    else
                    {
                        observableObject[i].SetActive(false);
                    }
                    break;
                case 2:
                    if (observableObject[i].GetComponent<Hint>().canBeSeenByPlum)
                    {
                        observableObject[i].SetActive(true);
                    }
                    else
                    {
                        observableObject[i].SetActive(false);
                    }
                    break;
            }
        }
    }*/
}
