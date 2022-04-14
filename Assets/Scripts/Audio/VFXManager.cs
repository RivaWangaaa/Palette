using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class VFXManager : MonoBehaviour
{
    public static VFXManager instance;
    
    //Sounds Effect
    public AudioSource[] vfx_BookPages;

    public AudioSource vfx_CandyGet;
    public AudioSource vfx_ClueFound;

    public AudioSource music_Hallway;
    public AudioSource music_MeetSnowie;

    public bool isInHallway;
    public float hallwayMusicDeltaSpeed;
    
    //wwise
    public GameObject[] hallwaySoundCubes;

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

    public void PlayRandomBookPageVFX()
    {
        int index = Random.Range(0, vfx_BookPages.Length);
        vfx_BookPages[index].Play();
    }

    private void Update()
    {
        if (isInHallway)
        {
            if (music_Hallway.volume <= 1)
            {
                music_Hallway.volume += hallwayMusicDeltaSpeed * Time.deltaTime;
            }
        }
        else
        {
            if (music_Hallway.volume >= 0)
            {
                music_Hallway.volume -= hallwayMusicDeltaSpeed * Time.deltaTime;
            }
        }
    }

    void UpdateSoundCube()
    {
        foreach (var cube in hallwaySoundCubes)
        {
            cube.GetComponent<AkTriggerEnter>().triggerObject = GameManager.instance.currentControllingPlayer;
            cube.GetComponent<AkTriggerExit>().triggerObject = GameManager.instance.currentControllingPlayer;
        }
    }
}
