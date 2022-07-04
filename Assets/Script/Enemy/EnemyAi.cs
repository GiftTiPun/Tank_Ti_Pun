using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAi : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float bulletspeed;
    [SerializeField] float rotation_angel = 0f;
    [SerializeField] bool canRotate = true;
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public Rigidbody2D enemyRb;
    public WallDetecting DetectWall;
    void Start()
    {
        enemy_Rotate();
        speed = gameObject.GetComponent<EnemyClass>().enemy_Speed;
        bulletspeed = gameObject.GetComponent<EnemyClass>().enemy_Bullet_Speed;
        enemyRb = gameObject.GetComponent<Rigidbody2D>();
        StartCoroutine(CooldownRotate(2f));
        StartCoroutine(CooldownShooting(bulletspeed));
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
        if (rotation_angel == 0)
        {
            enemyRb.MovePosition(enemyRb.position + (Vector2.up * speed) * Time.deltaTime);
        }
        else if (rotation_angel == 1)
        {
            enemyRb.MovePosition(enemyRb.position + (Vector2.left * speed) * Time.deltaTime);
        }
        else if (rotation_angel == 2)
        {
            enemyRb.MovePosition(enemyRb.position + (Vector2.down * speed) * Time.deltaTime);
        }
        else if (rotation_angel == 3)
        {
            enemyRb.MovePosition(enemyRb.position + (Vector2.right * speed) * Time.deltaTime);
        }
    }

    void enemy_Rotate()
    {
        if (canRotate)
        {
            Debug.Log("rotating");
            rotation_angel = Random.Range(0, 4);
            enemyRb.transform.eulerAngles = new Vector3(0, 0, rotation_angel * 90f);
            canRotate = false;
        }
        
        

    }

    private IEnumerator CooldownRotate(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            Debug.Log("cooldown");
            canRotate = true;
        }
    }
    private IEnumerator CooldownShooting(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            bullet.GetComponent<Rigidbody2D>().velocity = bulletSpawnPoint.up * 5;
        }
    }

}
