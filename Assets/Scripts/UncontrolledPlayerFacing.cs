using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UncontrolledPlayerFacing : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.LookAt(GameManager.instance.currentControllingPlayer.transform);
    }
}
