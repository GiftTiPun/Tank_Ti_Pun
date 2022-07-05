using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIStatPlayer : MonoBehaviour
{
    public Text Playerlife;
   
    void Update()
    {
        
        Playerlife.text = PlayerStat.PlayerHealth.ToString();
    }
}
