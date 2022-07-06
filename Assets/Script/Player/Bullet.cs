using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class Bullet : NetworkBehaviour
{
    public float stayTime = 2;
    Transform PlayerSpawnPoint;
    PlayerMovement test;
    PlayerStat player;
    string playername;
   
    public void Start()
    {
        test = GameObject.FindObjectOfType<PlayerMovement>();
        player = GameObject.FindObjectOfType<PlayerStat>();
        PlayerSpawnPoint = GameObject.FindGameObjectWithTag("SpawnPlayer").GetComponent<Transform>();
    }
    

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            PlayerStat.score += collision.gameObject.GetComponent<EnemyClass>().score;
            Debug.Log(PlayerStat.score);
            Destroy(collision.gameObject);
            Destroy(gameObject);
            PlayerMovement.offlinebullet = false;
            PlayerMovement.bulletActive = false;
        }
         if (collision.gameObject.tag == "Breakable_Wall" )
        {
            DestroybulletClientRpc();
            Destroy(gameObject);
            PlayerMovement.offlinebullet = false;
            PlayerMovement.bulletActive = false;
        }

         if (collision.gameObject.tag == "UNBreakable_Wall" )
        {

            DestroybulletClientRpc();
            Destroy(gameObject);
            PlayerMovement.offlinebullet = false;
            PlayerMovement.bulletActive = false;
        }
         if (collision.gameObject.tag == "Water") 
        {
           
            PlayerMovement.bulletActive = false;
        }
         if(collision.gameObject.tag == "EnemyBullet" )
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            DestroybulletClientRpc();
            PlayerMovement.offlinebullet = false;
            PlayerMovement.bulletActive = false;
        }
        if (collision.gameObject.tag == "Player" )
        {
            //PlayerStat.PlayerHealth -= 1;
            Debug.Log("Hit");
            DestroybulletClientRpc();
            Destroy(gameObject);

           /* player.hited()*/;

            OnlineRespawn.OnlinePlayerActive = false;
            collision.gameObject.SetActive(false);
                collision.gameObject.transform.position = PlayerSpawnPoint.position;
            collision.gameObject.SetActive(true);
            PlayerMovement.offlinebullet = false;
            PlayerMovement.bulletActive = false;
        }
    }

    

    [ServerRpc(RequireOwnership = false)]
    private void DestroybulletServerRpc()
    {
        Destroy(gameObject);
    }

    [ClientRpc]
    private void DestroybulletClientRpc()
    {
        DestroybulletServerRpc();
    }

   
}
