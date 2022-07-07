using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSpawn : MonoBehaviour
{
    [SerializeField] int Remaining_Enemy;
    [SerializeField] int spawnTime = 0;
    public Transform[] spawnpoint;
    public List<GameObject> Itemlist = new List<GameObject>();
    public Text Remain_EnemyText;

    private void Start()
    {
        Remaining_Enemy = GameObject.FindObjectOfType<EnemySpawn>().Enemylist.Count + GameObject.FindObjectOfType<EnemySpawn>().EnemyOnsite.Length;
    }

    private void Update()
    {
        Remaining_Enemy = GameObject.FindObjectOfType<EnemySpawn>().Enemylist.Count + GameObject.FindObjectOfType<EnemySpawn>().EnemyOnsite.Length;
        CheckSpawnItem();
        Remain_EnemyText.text = Remaining_Enemy.ToString();
    }

    void CheckSpawnItem()
    {
        if (Remaining_Enemy == 8 && spawnTime == 0)
        {
            SpawnItem();
        }
        else if (Remaining_Enemy == 5 && spawnTime == 1)
        {
            SpawnItem();
        }
        else if (Remaining_Enemy == 2 && spawnTime == 2)
        {
            SpawnItem();
        }
    }

    void SpawnItem()
    {
        spawnTime++;
        int randomItem = Random.Range(0, Itemlist.Count);
        int randomSpawnPoint = Random.Range(0, 3);
        Instantiate(Itemlist[randomItem].gameObject, spawnpoint[randomSpawnPoint].position, spawnpoint[randomSpawnPoint].rotation);
    }
}
