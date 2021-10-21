using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
    // Use this for initialization
    CharacterController cc;
    void Start () {
        cc = GetComponent<CharacterController>();
    }
 
    // Update is called once per frame
    void Update () {
        if (cc.isGrounded == true && cc.velocity.magnitude > 2f && GetComponent<AudioSource>().isPlaying == false)
        {
            GetComponent<AudioSource>().Play();
        }
    }
}
