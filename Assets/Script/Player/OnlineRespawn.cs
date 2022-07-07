using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class OnlineRespawn : NetworkBehaviour
{
    public NetworkVariable<int> playeringame = new NetworkVariable<int>();
    Transform PlayerSpawnPoint;
    public GameObject PlayerPrefab;
    public static bool OnlinePlayerActive =true;
    public GameObject alert;


    private void Update()
    {   
        Debug.Log("Num = "+playeringame.Value);
        if(playeringame.Value >=1)
        {
            alert.SetActive(true);
        }
        else
        {
            alert.SetActive(false);
        }
    }
    public int PlayerinGame
    {
        get
        {
            return playeringame.Value;
        }
    }

    private void Start()
    {
        PlayerSpawnPoint = GameObject.FindGameObjectWithTag("SpawnPlayer").GetComponent<Transform>();
        NetworkManager.Singleton.OnClientConnectedCallback += (id) =>
         {
             if(IsServer)
             playeringame.Value++;
         };
        NetworkManager.Singleton.OnClientDisconnectCallback += (id) =>
        {
            if (IsServer)
                playeringame.Value--;
        };
    }
   


}
