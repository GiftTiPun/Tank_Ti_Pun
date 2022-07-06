using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;

public class PlayerStat : NetworkBehaviour
{
    public static float PlayerHealth =3;
    public float moveSpeed = 2;
    public static float score ;
    public static float highscore;

    public static float onlineScore;
    public int OnlineHealth ;

    
    [SerializeField] Text LifePointText;

    public NetworkVariable<int> healthOnline = new NetworkVariable<int>();

    public int HealthOnline
    {
        get
        {
            return healthOnline.Value;
        }
    }


    public void Start()
    {
        
        healthOnline.Value = 5;
        OnlineHealth = 20;

    }

    //public void hited()
    //{

    //        LoseLifeaPointServerRpc(1);

    //}

    //[ClientRpc]
    //public void LoseLifePointClientRpc(int amount)
    //{
    //    OnlineHealth -= amount;
    //}
    //[ServerRpc(RequireOwnership = false)]
    //public void LoseLifeaPointServerRpc(int amount)
    //{
    //    LoseLifePointClientRpc(amount);
    //}

    //[ClientRpc]
    //public void CheckLifeClientRpc()
    //{
    //    LifePointText.text = OnlineHealth.ToString();
    //}
    //[ServerRpc(RequireOwnership = false)]
    //public void CheckLifeServerRpc()
    //{
    //    CheckLifeClientRpc();
    //}


}
