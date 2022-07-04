using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    public bool PlayerActive = false;
    Transform PlayerSpawnPoint;
    public GameObject PlayerPrefab;

    private void Start()
    {
        PlayerSpawnPoint = GameObject.FindGameObjectWithTag("SpawnPlayer").GetComponent<Transform>();
        
    }

    private void FixedUpdate()
    {
        ReSpawn();
    }
    //void fIXUpdate()
    //{
    //    ReSpawn();
        
    //}

    void ReSpawn()
    {
        if(PlayerActive == false)
        {
            var Createplayer = Instantiate(PlayerPrefab, PlayerSpawnPoint.position, PlayerSpawnPoint.rotation);
            PlayerActive = true;
        }
        else
        {
            Debug.Log("Alive");
        }
        
    }
    
}
