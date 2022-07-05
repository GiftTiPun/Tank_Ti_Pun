using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class Bullet : NetworkBehaviour
{
    public float stayTime = 2;
    
    PlayerMovement test;
    PlayerStat player;
    public void Start()
    {
        test = GameObject.FindObjectOfType<PlayerMovement>();
        player = GameObject.FindObjectOfType<PlayerStat>();
    }
    //void Awake()
    //{
    //    Destroy(gameObject, life);
       
    //}
   

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            PlayerStat.score += collision.gameObject.GetComponent<EnemyClass>().score;
            Debug.Log(PlayerStat.score);
            Destroy(collision.gameObject);
            Destroy(gameObject);
            PlayerMovement.bulletActive = false;
        }
         if (collision.gameObject.tag == "Breakable_Wall")
        {
            PlayerMovement.bulletActive = false;
        }

         if (collision.gameObject.tag == "UNBreakable_Wall")
        {

            DestroybulletServerRpc();
            PlayerMovement.bulletActive = false;
        }
         if (collision.gameObject.tag == "Water") 
        {
           
            Destroy(gameObject,2);
            PlayerMovement.bulletActive = false;
        }
         if(collision.gameObject.tag == "EnemyBullet")
        {
            Destroy(collision.gameObject);
            DestroybulletServerRpc();
            PlayerMovement.bulletActive = false;
        }
    }

    [ServerRpc(RequireOwnership = false)]
    private void DestroybulletServerRpc()
    {
        Destroy(gameObject);
    }
}
