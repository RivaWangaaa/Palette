using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintManager : MonoBehaviour
{
    public static HintManager instance;

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
        for (int i = 0; i < collectableObjects.Count; i++)
        {
            isHintCollected.Add(false);
        }
    }
    public void UpdateCollectedHints()
    {
        for(int i = 0; i < collectableObjects.Count; i++)
        {
            isHintCollected[i] = collectableObjects[i].GetComponent<Hint>().isCollected;
        }
    }
}
