using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
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
           
            Destroy(gameObject);
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
            Destroy(gameObject);
            PlayerMovement.bulletActive = false;
        }
    }
}
