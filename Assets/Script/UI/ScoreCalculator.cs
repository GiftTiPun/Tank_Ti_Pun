using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCalculator : MonoBehaviour
{
    PlayerStat player;
    public Text currentscore;
    void Start()
    {
        player = GameObject.FindObjectOfType<PlayerStat>();
        
    }

    // Update is called once per frame
    void Update()
    {
        currentscore.text = PlayerStat.score.ToString();
    }
}
