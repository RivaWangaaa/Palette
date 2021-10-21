using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text HintUIText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HintUIText.text = "Hints Collected" + "\n" + Player.hintCollect + " / " + Player.hintTotal;
    }
}
