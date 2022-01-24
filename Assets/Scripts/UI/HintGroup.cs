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
        unrevealedIcon.SetActive(false);
        subHintsIcon.SetActive(true);
    }

    public void RevealWithoutSubHint()
    {
        unrevealedIcon.SetActive(false);
        revrealedIcon.SetActive(true);
    }

    public void RevealWithSubHint()
    {
        subHintsIcon.SetActive(false);
        revrealedIcon.SetActive(true);
    }
}
