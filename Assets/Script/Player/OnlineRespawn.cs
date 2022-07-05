using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class OnlineRespawn : NetworkBehaviour
{
    public NetworkVariable<int> playeringame = new NetworkVariable<int>();

    private void Update()
    {
        
        Debug.Log("Num = "+playeringame.Value);
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
