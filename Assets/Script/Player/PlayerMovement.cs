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
    public static bool bulletActive = false;
    public static bool offlinebullet = false;
    OnlineRespawn totalPlayer;


    private void Start()
    {
        player = GameObject.FindObjectOfType<PlayerStat>();
        rePlayer = GameObject.FindObjectOfType<PlayerRespawn>();
       totalPlayer = GameObject.FindObjectOfType<OnlineRespawn>();
    }

    void Update()
    {
        if (IsClient && IsOwner)
        {
            MovementServerRpc();
            Die();

            if (totalPlayer.playeringame.Value >=1)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    ShootingServerRpc();
                    
                }
            }
        }
        else if((!IsClient && !IsOwner))
        {
            //MovementServerRpc();
            Movement();
            if (offlinebullet == false)
            {
                Shooting();
            }
            Die();
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

    [ServerRpc]
    void MovementServerRpc()
    {
        MovementClientRpc();
        //float h = Input.GetAxisRaw("Horizontal");
        //float v = Input.GetAxisRaw("Vertical");
        //if (h != 0)
        //{
        //    transform.position += new Vector3(h * player.moveSpeed * Time.deltaTime, 0, 0);
        //    transform.rotation = Quaternion.Euler(0, 0, -90 * h);
        //}
        //else if (v != 0)
        //{
        //    transform.position += new Vector3(0, v * player.moveSpeed * Time.deltaTime, 0);
        //    transform.rotation = Quaternion.Euler(0, 0, 90 - 90 * v);
        //}
    }
    [ClientRpc]
    void MovementClientRpc()
    {
        //MovementServerRpc();
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
            if (Input.GetKeyDown(KeyCode.Space))
            {
                var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
                bullet.GetComponent<Rigidbody2D>().velocity = bulletSpawnPoint.up * bulletSpeed;
                offlinebullet = true;

            }
        

    }
    void Die()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            rePlayer.PlayerActive = false;
            Debug.Log("Die");
            PlayerStat.PlayerHealth -= 1;
            Destroy(this.gameObject);
        }
    }

   

    [ServerRpc(Delivery = RpcDelivery.Reliable)]
    void ShootingServerRpc()
    {
        ShootingClientRpc();
        

    }
    [ClientRpc]
    void ShootingClientRpc()
    {
        
        NetworkObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation).GetComponent<NetworkObject>();
       

        bullet.GetComponent<Rigidbody2D>().velocity = bulletSpawnPoint.up * bulletSpeed;
        bullet.SpawnWithOwnership(OwnerClientId);
        bulletActive = true;

    }

    

}
