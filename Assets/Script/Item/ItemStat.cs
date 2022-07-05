using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemStat : MonoBehaviour
{
    public string itemname;

    private void Start()
    {
        Destroy(this.gameObject, 10f);
    }
}
