using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    public bool PlayerActive = false;
    public Transform PlayerSpawnPoint;
    public GameObject PlayerPrefab;

   
    void Update()
    {
        ReSpawn();
        
    }

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
    void Die()
    {
       
    }
}
