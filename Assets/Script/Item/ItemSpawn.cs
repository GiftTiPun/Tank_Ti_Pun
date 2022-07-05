using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawn : MonoBehaviour
{
    bool spawnCooldown;
    public Transform[] spawnpoint;
    public List<GameObject> Itemlist = new List<GameObject>();


    private void Awake()
    {

        spawnCooldown = false;
        StartCoroutine(SpawnEnemyCooldown(3f));
    }
    private void Start()
    {
        
    }

    private void Update()
    {
        
        if (!spawnCooldown )
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
        int randomEnemy = Random.Range(0, Itemlist.Count);
        int randomSpawnPoint = Random.Range(0, 3);
        Instantiate(Itemlist[randomEnemy].gameObject, spawnpoint[randomSpawnPoint].position, spawnpoint[randomSpawnPoint].rotation);
        spawnCooldown = true;

    }
}
