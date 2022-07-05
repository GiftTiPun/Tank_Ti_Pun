using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class itemAbility : MonoBehaviour
{
    public static int starReceive = 0;

    public GameObject LevelWallPrefab;

    public GameObject Shield;
    GameObject player;
    GameObject LevelWall;
    GameObject[] EnemiesOnSite;
    private void Start()
    {
        player = GameObject.FindGameObjectsWithTag("Player")[0];
        Invoke("ShieldDisable", 2f);
    }

    private void ShieldDisable()
    {
        Shield.SetActive(false);
    }

    private void Update()
    {       
        player = GameObject.FindGameObjectWithTag("Player");
        LevelWall = GameObject.FindGameObjectWithTag("LevelWall");
        EnemiesOnSite = GameObject.FindGameObjectsWithTag("Enemy");
        Shield.transform.position = player.transform.position;
        Shield.transform.rotation = player.transform.rotation;
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
            enemy.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            Debug.Log("freeze");
        }
        StartCoroutine(FrostTime(5f));
    }

    private IEnumerator FrostTime(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        foreach (GameObject enemy in EnemiesOnSite)
        {
            enemy.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            Debug.Log("unfreeze");
        }
    }
}
