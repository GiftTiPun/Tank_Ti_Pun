using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    bool spawnCooldown;
    public Transform[] spawnpoint;
    public GameObject[] EnemyOnsite;
    public List<GameObject> Enemylist = new List<GameObject>();


    private void Awake()
    {
        
        spawnCooldown = false;
        StartCoroutine(SpawnEnemyCooldown(3f));
    }
    private void Start()
    {
        EnemyOnsite = GameObject.FindGameObjectsWithTag("Enemy");
    }

    private void Update()
    {
        EnemyOnsite = GameObject.FindGameObjectsWithTag("Enemy");
        if (!spawnCooldown && EnemyOnsite.Length<4)
        {
            SpawnEnemy();
        }
    }

    private IEnumerator SpawnEnemyCooldown(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            spawnCooldown = false;
        }
    }

    void SpawnEnemy()
    {
        int randomEnemy = Random.Range(0, Enemylist.Count);
        int randomSpawnPoint = Random.Range(0, 3);
        Instantiate(Enemylist[randomEnemy].gameObject, spawnpoint[randomSpawnPoint].position, spawnpoint[randomSpawnPoint].rotation);
        Enemylist.RemoveAt(randomEnemy);
        spawnCooldown = true;

    }
}
