using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedAdults : MonoBehaviour
{
    public GameObject head;
    // Transforms to act as start and end markers for the journey.
    private Vector3 startMarker;
    private Vector3 endMarker;

    public float movingTime;
    public bool movingDirection;
    public bool isMoving;
    // Time when the movement started.
    private float startTime;

    // Total distance between the markers.
    private float journeyLength;

    private float timePassed;

    private float distCovered;

    private float fractionOfJourney;

    private float calculatedSpeed;
    void Start()
    {
        //TODO: give endMarker the value of Player's Camera Value
        endMarker = GameManager.instance.currentControllingPlayer.GetComponent<Player>().adultHeadBendingPoint.position;
        startMarker = transform.position;
    }

    // Move to the target end position.
    void Update()
    {
        if (isMoving)
        {
            if (movingDirection)
            {
                //Descending
                DescendHead();
            }
            else
            {
                //Ascending
                AscendHead();
            }
        }
    }

    private void HeadLerpTrigger(bool startToDescend)
    {
        startTime = Time.time;
        journeyLength = Vector3.Distance(startMarker, endMarker);
        calculatedSpeed = journeyLength / movingTime;
        movingDirection = startToDescend;
        isMoving = true;
    }
    
    private void DescendHead()
    {
        // Distance moved equals elapsed time times speed..
        distCovered = (Time.time - startTime) * calculatedSpeed * Time.deltaTime;

        // Fraction of journey completed equals current distance divided by total distance.
        fractionOfJourney = distCovered / journeyLength;

        // Set our position as a fraction of the distance between the markers.
        head.transform.position = Vector3.Lerp(startMarker, endMarker, fractionOfJourney);
        Debug.Log(Vector3.Lerp(endMarker, startMarker, fractionOfJourney));
        if (fractionOfJourney >= 1f)
        {
            isMoving = false;
        }
    }
    
    private void AscendHead()
    {
        // Distance moved equals elapsed time times speed..
        distCovered = (Time.time - startTime) * calculatedSpeed * Time.deltaTime;

        // Fraction of journey completed equals current distance divided by total distance.
        fractionOfJourney = distCovered / journeyLength;

        // Set our position as a fraction of the distance between the markers.
        head.transform.position = Vector3.Lerp(endMarker, startMarker, fractionOfJourney);
        Debug.Log(Vector3.Lerp(endMarker, startMarker, fractionOfJourney));
        if (fractionOfJourney >= 1f)
        {
            isMoving = false;
        }
    }
}
