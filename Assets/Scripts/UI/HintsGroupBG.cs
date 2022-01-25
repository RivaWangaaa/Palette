using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HintsGroupBG : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public float colorAlphaSpeed;
    private Image pinkImage;

    private void Start()
    {
        pinkImage = GetComponent<Image>();
    }

    private void FixedUpdate()
    {
        Color tempColor = pinkImage.color;

        tempColor.a += colorAlphaSpeed * Time.deltaTime;

        pinkImage.color = tempColor;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        colorAlphaSpeed = 5;
    }
    
    public void OnPointerExit(PointerEventData eventData)
    {
        colorAlphaSpeed = -5;
    }
}
