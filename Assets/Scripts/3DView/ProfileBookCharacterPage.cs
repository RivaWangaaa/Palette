using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProfileBookCharacterPage : MonoBehaviour
{
    public List<ProfileBookClueGroup> profiles;

    //called when observe background clues
    public void unlockProfiles(ProfileBookClueGroup profile, bool isAfterBranch)
    {
        if (!isAfterBranch && !profile.isBeforeUnlocked)
        {
            //play animation
            UIManager.instance.messageBox.GetComponent<Animator>().SetTrigger("ObtainProfile");
            profile.unlockBefore();
            //get candy
            GameManager.instance.IncreaseCandy(1);
        }
        if (isAfterBranch && !profile.isAfterUnlocked)
        {
            UIManager.instance.messageBox.GetComponent<Animator>().SetTrigger("ObtainProfile");
            profile.unlockAfter();
            GameManager.instance.IncreaseCandy(1);
        }
    }
}
