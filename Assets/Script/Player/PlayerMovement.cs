using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class PlayerMovement : NetworkBehaviour
{
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    PlayerStat player;
    PlayerRespawn rePlayer;
    public float bulletSpeed = 5;
    public bool bulletActive = false;
    

    private void Start()
    {
        player = GameObject.FindObjectOfType<PlayerStat>();
        rePlayer = GameObject.FindObjectOfType<PlayerRespawn>();
        
    }

    void Update()
    {
        if (IsClient && IsOwner)
        {
            Movement();

            Die();
        }
        else
        {
            Movement();
            Shooting();
            Die();
        }
        if (bulletPrefab.GetComponent<NetworkObject>().IsOwner)
        {
            ShootingServerRpc();
        }
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

    void Shooting()
    {
        if (bulletActive == false)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
                bullet.GetComponent<Rigidbody2D>().velocity = bulletSpawnPoint.up * bulletSpeed;
                bulletActive = true;
            }
        }

    }
    void Die()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            rePlayer.PlayerActive = false;
            Debug.Log("Die");
            player.PlayerHealth -= 1;
            Destroy(this.gameObject);
        }
    }


    [ServerRpc(RequireOwnership = false)]
    void ShootingServerRpc()
    {
        ShootingClientRpc();

    }
    [ClientRpc]
    void ShootingClientRpc()
    {
        
        if (bulletActive == false)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
                bullet.GetComponent<Rigidbody2D>().velocity = bulletSpawnPoint.up * bulletSpeed;
                bulletActive = true;
            }
        }

    }

    //Online Test
    //private void FixedUpdate()
    //{
    //    if (IsClient && IsOwner)
    //    {
    //        Movement();

    //    }

    //}
}
