using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UncontrolledPlayerFacing : MonoBehaviour
{
    public bool isAdultHead;
    // Update is called once per frame
    void Update()
    {
        if (isAdultHead)
        {
            Vector3 targetLookAtPosition = new Vector3(GameManager.instance.currentControllingPlayer.transform.position.x,
                GameManager.instance.currentControllingPlayer.transform.position.y, 
                GameManager.instance.currentControllingPlayer.transform.position.z);
            transform.LookAt(targetLookAtPosition);
        }
        else
        {
            Vector3 targetLookAtPosition = new Vector3(GameManager.instance.currentControllingPlayer.transform.position.x,
                transform.position.y, GameManager.instance.currentControllingPlayer.transform.position.z);
            transform.LookAt(targetLookAtPosition);
        }

    }
}
