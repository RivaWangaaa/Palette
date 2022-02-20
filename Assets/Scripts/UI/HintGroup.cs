using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class HintGroup : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject unrevealedIcon;
    public GameObject revrealedIcon;
    public GameObject subHintsIcon;

    public string details;
    public bool isOnLeft;

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
        if (revrealedIcon.activeSelf == false)
        {
            UIManager.instance.messageBox.GetComponent<Animator>().SetTrigger("ObtainHint");
        }
        subHintsIcon.SetActive(false);
        unrevealedIcon.SetActive(false);
        revrealedIcon.SetActive(true);
    }
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (revrealedIcon.activeSelf)
        {
            if (isOnLeft)
            {
                UIManager.instance.cludGroupDetail_Right.SetActive(true);
                UIManager.instance.cludGroupDetail_Right.transform.GetChild(0).GetComponent<Text>().text = details;
            }
            else
            {
                UIManager.instance.clueGroupDetail_Left.SetActive(true);
                UIManager.instance.cludGroupDetail_Right.transform.GetChild(0).GetComponent<Text>().text = details;
            }
        }
    }
    
    public void OnPointerExit(PointerEventData eventData)
    {
        if (isOnLeft)
        {
            UIManager.instance.cludGroupDetail_Right.SetActive(false);
        }
        else
        {
            UIManager.instance.clueGroupDetail_Left.SetActive(false);
        }
    }
}
