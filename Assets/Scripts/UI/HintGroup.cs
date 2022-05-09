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
    
    public GameObject hintGroupDetail;
    
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
            //VFXManager.instance.vfx_ClueFound.Play();
        }
        subHintsIcon.SetActive(false);
        unrevealedIcon.SetActive(false);
        revrealedIcon.SetActive(true);
        //after reveal a hint group, check if the whole clue group is clear
        transform.parent.gameObject.GetComponent<ClueGroup>().CheckIfClueClear();
    }
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        
    }
    
    public void OnPointerExit(PointerEventData eventData)
    {

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        //VFXManager.instance.PlayRandomBookPageVFX();
        Debug.Log(gameObject.name);
        if (revrealedIcon.activeSelf)
        {
            if (UIManager.instance.currentShowingHintGroupDetail != null)
            {
                UIManager.instance.currentShowingHintGroupDetail.SetActive(false);
            }
            hintGroupDetail.SetActive(true);
            UIManager.instance.currentShowingHintGroupDetail = hintGroupDetail;
        }
    }
}
