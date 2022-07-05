using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UISceneManager : MonoBehaviour
{
    PlayerStat player;
    EnemySpawn currentEnemy;
    public GameObject passText;

    private void Start()
    {
        player = GameObject.FindObjectOfType<PlayerStat>();
        currentEnemy = GameObject.FindObjectOfType<EnemySpawn>();
    }

    private void FixedUpdate()
    {
        if (PlayerStat.PlayerHealth <= 0)
        {
            BackToMenu();
            PassValue.currentlevel = 1;
            PlayerStat.score = 0;
            PlayerStat.PlayerHealth = 3;

        }
        if(currentEnemy.EnemyOnsite.Length == 0 && currentEnemy.Enemylist.Count ==0)
        {
            StartCoroutine(coroutineA());
            
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
    }
    public void GotoLoading()
    {
        SceneManager.LoadScene("LoadingStage");
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
