using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class HintGroup : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public GameObject unrevealedIcon;
    public GameObject revrealedIcon;
    public GameObject subHintsIcon;

    public string details;
    public bool isOnLeft;

    public GameObject clueGroupDetail;

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
        
    }
    
    public void OnPointerExit(PointerEventData eventData)
    {

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log(gameObject.name);
        if (revrealedIcon.activeSelf)
        {
            UIManager.instance.currentShowingClueGroupDetail.SetActive(false);
            clueGroupDetail.SetActive(true);
            clueGroupDetail = UIManager.instance.currentShowingClueGroupDetail;
        }
    }
}
