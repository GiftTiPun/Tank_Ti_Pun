using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyClass 
{
    float enemy_Health;
    float enemy_Speed;
    float enemy_Bullet_Speed;

    public EnemyClass(float enemy_Health, float enemy_Speed, float enemy_Bullet_Speed)
    {
        this.Enemy_Health = enemy_Health;
        this.Enemy_Speed = enemy_Speed;
        this.Enemy_Bullet_Speed = enemy_Bullet_Speed;
    }

    public float Enemy_Health { get => enemy_Health; set => enemy_Health = value; }
    public float Enemy_Speed { get => enemy_Speed; set => enemy_Speed = value; }
    public float Enemy_Bullet_Speed { get => enemy_Bullet_Speed; set => enemy_Bullet_Speed = value; }
}
