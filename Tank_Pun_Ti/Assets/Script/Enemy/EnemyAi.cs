using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAi : MonoBehaviour
{
    float speed;
    float rotation_angel = 0;
    
    WallDetecting DetectWall;
    void Start()
    {
        speed = this.gameObject.GetComponent<EnemyClass>().Enemy_Speed;
    }

    
    void Update()
    {
        enemy_Walk();
        if (DetectWall.Istouching_Wall)
        {
            enemy_Rotate();
        }
    }

    void enemy_Walk()
    {
        transform.position = new Vector3(transform.position.x + speed,0,0);
    }

    void enemy_Rotate()
    {
        
    }
}
