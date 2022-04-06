using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXManager : MonoBehaviour
{
    public static VFXManager instance;
    
    //Sounds Effect
    public AudioSource vfx_BookPage1;
    public AudioSource vfx_BookPage2;
    public AudioSource vfx_BookPage3;

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
}
