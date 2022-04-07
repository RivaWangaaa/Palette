using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXManager : MonoBehaviour
{
    public static VFXManager instance;
    
    //Sounds Effect
    public AudioSource[] vfx_BookPages;

    public AudioSource vfx_CandyGet;
    public AudioSource vfx_ClueFound;
    
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
}
