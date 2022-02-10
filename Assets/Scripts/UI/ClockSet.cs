using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockSet : MonoBehaviour
{
    public void IncrementTime(int costTime)
    {
        GameManager.instance.IncreaseTime(costTime);
    }
}
