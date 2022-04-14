using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PausePanel3DInteractableObjects : MonoBehaviour
{
    public UnityEvent onMouseDownMethod;
    public GameObject artPotrait;
    private SpriteRenderer spriteRenderer;
    private Sprite originalSprite;
    
    [SerializeField] private Sprite changeSprite;

    private void Start()
    {
        spriteRenderer = artPotrait.GetComponent<SpriteRenderer>();
        originalSprite = artPotrait.GetComponent<SpriteRenderer>().sprite;
    }

    private void OnMouseEnter()
    {
        Debug.Log("sprite change to new");
        spriteRenderer.sprite = changeSprite;
    }

    private void OnMouseDown()
    {
        Debug.Log("show pause panel");
        onMouseDownMethod.Invoke();
    }

    private void OnMouseExit()
    {
        Debug.Log("sprite back to original");
        spriteRenderer.sprite = originalSprite;
    }
}
