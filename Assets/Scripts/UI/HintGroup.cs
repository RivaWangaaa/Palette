using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HintGroup : MonoBehaviour
{
    public GameObject unrevealedIcon;
    public GameObject revrealedIcon;
    public GameObject subHintsIcon;

    public void GetSubHints()
    {
        if (revrealedIcon.activeSelf == false)
        {
            unrevealedIcon.SetActive(false);
            subHintsIcon.SetActive(true);
            Debug.Log("show subhint");
        }
        else
        {
            Debug.Log("you already get the hint");
        }
        
    }

    public void RevealThisHint()
    {
        subHintsIcon.SetActive(false);
        unrevealedIcon.SetActive(false);
        revrealedIcon.SetActive(true);
        UIManager.instance.messageBox.GetComponent<Animator>().SetTrigger("ObtainHint");
    }
}
