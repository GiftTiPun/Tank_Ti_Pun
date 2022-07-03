using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float life = 3;
    float num = 0;
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
            player.score += 1000;
            Debug.Log(player.score);
            Destroy(collision.gameObject);
            Destroy(gameObject);
            checkBullet.bulletActive = false;
        }
        else if(collision.gameObject.tag == "UNBreakable_Wall")
        {
            player.score -= 50;
            Debug.Log(player.score);
            Destroy(gameObject);
            checkBullet.bulletActive = false;
        }
    }
}
