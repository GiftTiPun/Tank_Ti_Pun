using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UISceneManager : MonoBehaviour
{
    PlayerStat player;

    private void Start()
    {
        player = GameObject.FindObjectOfType<PlayerStat>();
    }

    private void FixedUpdate()
    {
        if(player.PlayerHealth <=0)
        {
            BackToMenu();
            PassValue.currentlevel = 1;
            
        }
    }
    public void GotoHostJoin()
    {
        SceneManager.LoadScene(2);
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene(1);
    }
    public void GotoGame()
    {
        SceneManager.LoadScene("Level1");
    }
    public void PassLevel()
    {
        PassValue.currentlevel += 1;
        SceneManager.LoadScene("ScoreCal");
    }
    public void NextLevel()
    {
        SceneManager.LoadScene("Level"+ PassValue.currentlevel);
    }
}
