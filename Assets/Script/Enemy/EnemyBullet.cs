using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("player mongteng");
        }
        else if (collision.gameObject.tag == "UNBreakable_Wall"|| collision.gameObject.tag == "Breakable_Wall")
        {
            Destroy(this.gameObject);
        }
    }
}
