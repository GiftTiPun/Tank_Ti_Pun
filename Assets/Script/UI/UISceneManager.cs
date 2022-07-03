using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UISceneManager : MonoBehaviour
{
    
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
