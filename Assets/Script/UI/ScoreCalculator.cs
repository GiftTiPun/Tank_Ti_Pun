using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCalculator : MonoBehaviour
{
    PlayerStat player;
    public Text currentscore;
    public Text highscoreText;
    
    void Start()
    {
       PlayerStat.highscore = PlayerPrefs.GetFloat("Highscore");
    }

    // Update is called once per frame
    void Update()
    {
        currentscore.text = PlayerStat.score.ToString();
        highscoreText.text = PlayerStat.highscore.ToString();
        if(PlayerStat.score >= PlayerStat.highscore)
        {
            PlayerPrefs.SetFloat("Highscore", PlayerStat.score);
        }
        PlayerStat.highscore = PlayerPrefs.GetFloat("Highscore");

    }
}
