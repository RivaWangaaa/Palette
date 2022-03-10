using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockSet : MonoBehaviour
{
    public void IncrementTime()
    {
        int costTime = 58 - GameManager.instance.currentLoopTimeMinute;
        GameManager.instance.IncreaseTime(costTime);
    }

    public void ResetTime()
    {
        int costTime = -GameManager.instance.currentLoopTimeMinute;
        GameManager.instance.IncreaseTime(costTime);
    }
}
