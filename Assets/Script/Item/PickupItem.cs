using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour
{
    string itemname;
    itemAbility itemEffect;

    private void Start()
    {
        itemEffect = GameObject.FindObjectOfType<itemAbility>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "item")
        {
            itemname = collision.GetComponent<ItemStat>().itemname;
            if(itemname == "ExtraLife")
            {
                itemEffect.Item_ExtraLife();
            }
            else if(itemname == "FixWall")
            {
                itemEffect.Item_FixWall();
            }
            else if (itemname == "Granade")
            {
                itemEffect.Item_Granade();
            }
            else if (itemname == "Shield")
            {
                itemEffect.Item_Shield();
            }
            else if (itemname == "Star")
            {
                itemEffect.Item_Star();
            }
            else if (itemname == "Timer")
            {
                itemEffect.Item_Timer();
            }
            Destroy(collision.gameObject);
        }
        
    }

}
