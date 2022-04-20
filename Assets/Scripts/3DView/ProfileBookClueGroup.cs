using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProfileBookClueGroup : MonoBehaviour
{
    public GameObject Takeaways;
    public GameObject beforeTakeaways;
    public GameObject afterTakeaways;

    public GameObject but_Takeaways;

    public bool isBeforeUnlocked;
    public bool isAfterUnlocked;

    public bool isProfileBookClueBookOpen;

    public void unlockBefore()
    {
        beforeTakeaways.SetActive(true);
        isBeforeUnlocked = true;
        but_Takeaways.SetActive(true);
    }
    
    public void unlockAfter()
    {
        afterTakeaways.SetActive(true);
        isAfterUnlocked = true;
    }
    
    public void ClueBookToggle()
    {
        if (isProfileBookClueBookOpen)
        {
            Takeaways.SetActive(false);
            isProfileBookClueBookOpen = false;
        }
        else
        {
            foreach (var profile in gameObject.transform.parent.gameObject.GetComponent<ProfileBookCharacterPage>().profiles)
            {
                if (profile.isProfileBookClueBookOpen)
                {
                    profile.Takeaways.SetActive(false);
                    profile.isProfileBookClueBookOpen = false;
                }
            }
            Takeaways.SetActive(true);
            isProfileBookClueBookOpen = true;
        }
    }
}
