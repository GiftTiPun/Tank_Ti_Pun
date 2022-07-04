using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DestroyWall : MonoBehaviour
{
    public Tilemap BreakAbleTilemap;
    PlayerMovement checkBullet;
    void Start()
    {
        BreakAbleTilemap = GetComponent<Tilemap>();
        checkBullet = GameObject.FindObjectOfType<PlayerMovement>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Bullet"))
        {
            Vector3 hitposition = Vector3.zero;
            foreach(ContactPoint2D hit in collision.contacts)
            {
                hitposition.x = hit.point.x - 0.01f * hit.normal.x;
                hitposition.y = hit.point.y - 0.01f * hit.normal.y;
                BreakAbleTilemap.SetTile(BreakAbleTilemap.WorldToCell(hitposition), null);
                Destroy(collision.gameObject);
                
            }
        }
    }
}
