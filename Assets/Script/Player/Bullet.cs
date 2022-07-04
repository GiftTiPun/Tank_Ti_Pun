using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float life = 3;
    
    PlayerMovement checkBullet;
    PlayerStat player;
    public void Start()
    {
        checkBullet = GameObject.FindObjectOfType<PlayerMovement>();
        player = GameObject.FindObjectOfType<PlayerStat>();
    }
    void Awake()
    {
        Destroy(gameObject, life);
       
    }
   

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag== "Enemy")
        {
            PlayerStat.score += 1000;
            Debug.Log(PlayerStat.score);
            Destroy(collision.gameObject);
            Destroy(gameObject);
            checkBullet.bulletActive = false;
        }
        if (collision.gameObject.tag == "Breakable_Wall")
        {
            checkBullet.bulletActive = false;
        }

        else if(collision.gameObject.tag == "UNBreakable_Wall")
        {
            PlayerStat.score -= 50;
            Debug.Log(PlayerStat.score);
            Destroy(gameObject);
            checkBullet.bulletActive = false;
        }
    }
}
