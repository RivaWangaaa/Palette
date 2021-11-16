using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintManager : MonoBehaviour
{
    public static HintManager instance;

    //this should be replaced with Dictionary in the future
    public List<GameObject> collectableObjects;
    public List<bool> isHintCollected;

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
        for (int i = 0; i < collectableObjects.Count; i++)
        {
            isHintCollected.Add(false);
        }
    }

    //used when player collect an object or hint stuff
    public void UpdateCollectedHints()
    {
        for(int i = 0; i < collectableObjects.Count; i++)
        {
            isHintCollected[i] = collectableObjects[i].GetComponent<Hint>().isCollected;
        }
    }
}
