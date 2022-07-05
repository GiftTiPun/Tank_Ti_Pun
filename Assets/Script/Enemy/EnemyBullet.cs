using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    PlayerRespawn rePlayer;
    private void Start()
    {
       
        rePlayer = GameObject.FindObjectOfType<PlayerRespawn>();

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            rePlayer.PlayerActive = false;
            PlayerStat.PlayerHealth -= 1;
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }


        if (collision.gameObject.tag == "UNBreakable_Wall")
        {

            Destroy(gameObject);

        }
        if (collision.gameObject.tag == "Water")
        {

            Destroy(gameObject, 2);

        }
    }
}
