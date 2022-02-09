using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UncontrolledPlayerFacing : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        Vector3 targetLookAtPosition = new Vector3(GameManager.instance.currentControllingPlayer.transform.position.x,
            transform.position.y, GameManager.instance.currentControllingPlayer.transform.position.z);
        transform.LookAt(targetLookAtPosition);
    }
}
