using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetDestroy : MonoBehaviour
{
    UISceneManager uiManager;
    private void Start()
    {
        uiManager = FindObjectOfType<UISceneManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "EnemyBullet" || collision.tag == "Bullet")
        {
            Destroy(gameObject);
            uiManager.BackToMenu();       
        }
    }
}
