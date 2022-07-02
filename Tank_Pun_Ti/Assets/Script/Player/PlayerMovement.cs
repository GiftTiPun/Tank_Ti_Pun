using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    PlayerStat player;
    PlayerRespawn rePlayer;
    public float bulletSpeed = 10;
    public bool bulletActive = false;

    private void Start()
    {
        player = GameObject.FindObjectOfType<PlayerStat>();
        rePlayer = GameObject.FindObjectOfType<PlayerRespawn>();
        player.PlayerHealth = 20;
    }
    void Update()
    {
        Movement();
        Shooting();
        Die();
    }

    void Movement()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        if (h != 0)
        {
            transform.position += new Vector3(h * player.moveSpeed * Time.deltaTime, 0, 0);
            transform.rotation = Quaternion.Euler(0, 0, -90 * h);
        }
        else if (v != 0)
        {
            transform.position += new Vector3(0, v * player.moveSpeed * Time.deltaTime, 0);
            transform.rotation = Quaternion.Euler(0, 0, 90 - 90 * v);
        }
    }
   
    void Die()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            rePlayer.PlayerActive = false;
            Debug.Log("Die");
            Destroy(this.gameObject);
        }
    }



    void Shooting()
    {
        if(bulletActive == false)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
                bullet.GetComponent<Rigidbody2D>().velocity = bulletSpawnPoint.up * bulletSpeed;
                bulletActive = true;
            }
        }
        
    }
}
