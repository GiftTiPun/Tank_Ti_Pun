using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class itemAbility : MonoBehaviour
{
    [SerializeField] static int starReceive = 0;

    public GameObject LevelWallPrefab;

    GameObject Shield;
    GameObject player;
    GameObject LevelWall;
    GameObject[] EnemiesOnSite;
    private void Start()
    {
        player = GameObject.FindGameObjectsWithTag("Player")[0];
    }
    private void Update()
    {       
        player = GameObject.FindGameObjectsWithTag("Player")[0];
        Shield = GameObject.Find("/" + player.name + "/Shield");
        LevelWall = GameObject.FindGameObjectsWithTag("LevelWall")[0];
        EnemiesOnSite = GameObject.FindObjectOfType<EnemySpawn>().EnemyOnsite;
    }
    public void Item_ExtraLife()
    {
        PlayerStat.PlayerHealth++; 
    }

    public void Item_Shield()
    {
        Shield.SetActive(true);
        StartCoroutine(SheildTime(5f));
    }
    private IEnumerator SheildTime(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        Shield.SetActive(false);
    }

    public void Item_Star()
    {
        starReceive++;
    }

    public void Item_FixWall()
    {
        Destroy(LevelWall);
        Instantiate(LevelWallPrefab);
    }
    public void Item_Granade()
    {
        foreach(GameObject enemy in EnemiesOnSite)
        {
            Destroy(enemy.gameObject);
        }
    }
    public void Item_Timer()
    {
        foreach (GameObject enemy in EnemiesOnSite)
        {
            enemy.GetComponent<EnemyAi>().speed =0;
            enemy.GetComponent<EnemyAi>().bulletspeed = 0; 
        }
        StartCoroutine(FrostTime(5f));

        foreach (GameObject enemy in EnemiesOnSite)
        {
            enemy.GetComponent<EnemyAi>().speed = enemy.GetComponent<EnemyClass>().enemy_Speed;
            enemy.GetComponent<EnemyAi>().bulletspeed = enemy.GetComponent<EnemyClass>().enemy_Bullet_Speed;
        }

    }

    private IEnumerator FrostTime(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);           
    }
}
