using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text NPCHintUIText;
    public Text ItemHintUIText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        NPCHintUIText.text = "NPC Hints Collected" + "\n" + Player.npcHintCollect + " / " + Player.npcHintTotal;
        ItemHintUIText.text = "Item Hints Collected" + "\n" + Player.itemHintCollect + " / " + Player.itemHintTotal;
    }
}
