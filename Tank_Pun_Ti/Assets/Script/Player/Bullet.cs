using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float life = 3;
    PlayerMovement test;
    public void Start()
    {
        test = GameObject.FindObjectOfType<PlayerMovement>();
    }
    void Awake()
    {
        Destroy(gameObject, life);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag== "Enemy")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            test.bulletActive = false;
        }
        else if(collision.gameObject.tag == "UNBreakable_Wall")
        {
            Destroy(gameObject);
            test.bulletActive = false;
        }
    }
}
