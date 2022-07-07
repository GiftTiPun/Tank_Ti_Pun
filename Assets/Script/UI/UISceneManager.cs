using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UISceneManager : MonoBehaviour
{
    PlayerStat player;
    EnemySpawn currentEnemy;
    public GameObject passText;
    PlayerRespawn rePlayer;
    public GameObject uiTT1, uiTT2, uiTT3, uiTT4;

    private void Start()
    {
        player = GameObject.FindObjectOfType<PlayerStat>();
        currentEnemy = GameObject.FindObjectOfType<EnemySpawn>();
        rePlayer = GameObject.FindObjectOfType<PlayerRespawn>();
        if(PassValue.currentlevel == 1)
        {
            Time.timeScale = 0f;
        }
        
    }

    private void FixedUpdate()
    {
        currentEnemy = GameObject.FindObjectOfType<EnemySpawn>();
        if (PlayerStat.PlayerHealth <= 0)
        {
            BackToMenu();
            

        }
        if (rePlayer != null)
        {
            if (currentEnemy.EnemyOnsite.Length == 0 && currentEnemy.Enemylist.Count == 0)
            {
                StartCoroutine(coroutineA());

            }
        }

    }

    IEnumerator coroutineA()
    {
        // wait for 1 second
        Debug.Log("coroutineA created");
        yield return new WaitForSeconds(1.0f);
        passText.SetActive(true);
        yield return new WaitForSeconds(3.0f);
        Debug.Log("coroutineA running again");
        PassLevel();
    }
    public void GotoHostJoin()
    {
        SceneManager.LoadScene(2);
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene(1);
        resetValue();
    }
    public void GotoLoading()
    {
        if (PassValue.currentlevel < 5)
        {
            SceneManager.LoadScene("LoadingStage");
        }
        else
        {

            BackToMenu();
        }
    }

    public void PassLevel()
    {
        PassValue.currentlevel += 1;
        SceneManager.LoadScene("ScoreCal");
    }



    public void NextLevel()
    {
        if (PassValue.currentlevel < 5)
        {
            SceneManager.LoadScene("Level" + PassValue.currentlevel);
        }
        else
        {
            BackToMenu();
        }
    }

    public void resetValue()
    {
        PassValue.currentlevel = 1;
        PlayerStat.score = 0;
        PlayerStat.PlayerHealth = 3;
    }

    public void Tutorial1()
    {
        uiTT1.SetActive(false);
    }
    public void Tutorial2()
    {
        uiTT2.SetActive(false);
    }
    public void Tutorial3()
    {
        uiTT3.SetActive(false);
    }
    public void Tutorial4()
    {
        uiTT4.SetActive(false);
        Time.timeScale = 1f;
    }
}
