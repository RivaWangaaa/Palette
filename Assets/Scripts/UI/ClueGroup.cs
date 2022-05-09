using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClueGroup : MonoBehaviour
{
    public GameObject titleUnRevealed;
    public GameObject titleRevealed;
    public GameObject clueClearPhoto;

    public List<HintGroup> hintsInThisGroup;

    public void CheckIfClueClear()
    {
        int hintsClearCount = 0;
        for (int i = 0; i < hintsInThisGroup.Count; i++)
        {
            if (hintsInThisGroup[i].revrealedIcon.activeSelf)
            {
                hintsClearCount++;
            }
        }

        if (hintsClearCount == hintsInThisGroup.Count)
        {
            clueClearPhoto.SetActive(true);
            foreach (var hintGroup in hintsInThisGroup)
            {
                //hintGroup.gameObject.GetComponent<Image>().raycastTarget = false;
            }
        }
    }
}
