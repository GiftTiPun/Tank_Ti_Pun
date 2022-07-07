using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceTile : MonoBehaviour
{
    PlayerStat playerstat;
    private void Start()
    {
        playerstat = GameObject.FindObjectOfType<PlayerStat>();   
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            playerstat.moveSpeed = 5;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            StartCoroutine(slowDown(3f));
            StartCoroutine(slowDown(2f));
        }
    }

    IEnumerator slowDown(float speed)
    {  
        yield return new WaitForSeconds(1f);
        playerstat.moveSpeed = speed;
        
    }
}
