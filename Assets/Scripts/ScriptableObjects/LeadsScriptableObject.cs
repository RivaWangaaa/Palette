using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Leads",
    menuName = "ScriptableObject/Lead", order = 0)]

public class LeadsScriptableObject : ScriptableObject
{
    public Vector2Int positionInLeadsPool;
    public string leadContent;
    
    //if player already bought this lead
    public bool isBought;
    
    //if player already collect the hint
    public bool isHintCollected;


}