using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageUI : MonoBehaviour
{
  
    public Text currentstage;
   

    // Update is called once per frame
    void Update()
    {
        currentstage.text = PassValue.currentlevel.ToString();
    }
}
