using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIStatPlayer : MonoBehaviour
{
    public Text Playerlife;
    PlayerStat player;
    // Start is called before the first frame update
    void Start()
    {
        
        player = GameObject.FindObjectOfType<PlayerStat>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(player.PlayerHealth);
        Playerlife.text = player.PlayerHealth.ToString();
    }
}
