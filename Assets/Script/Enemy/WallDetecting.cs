using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDetecting : MonoBehaviour
{
    public bool Istouching_Wall = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Breakable_Wall"|| collision.tag == "UNBreakable_Wall"||collision.tag == "Enemy")
        {
            Istouching_Wall = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Breakable_Wall" || collision.tag == "UNBreakable_Wall"|| collision.tag == "Enemy")
        {
            Istouching_Wall = false;
        }
    }
}
