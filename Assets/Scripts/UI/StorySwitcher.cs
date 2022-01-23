using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class StorySwitcher : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private float slideSpeed;
    private Vector3 tempPos;
    private void Start()
    {
        
    }

    private void FixedUpdate()
    {
        tempPos = gameObject.GetComponent<RectTransform>().localPosition;
        
        tempPos.x += slideSpeed;

        gameObject.GetComponent<RectTransform>().localPosition = tempPos;
        
        if (tempPos.x <= -780 || tempPos.x >= -580)
        {
            slideSpeed = 0;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        slideSpeed = -4;
    }
    
    public void OnPointerExit(PointerEventData eventData)
    {
        slideSpeed = 4;
    }
}
