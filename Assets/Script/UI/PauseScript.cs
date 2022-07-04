using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    bool timecheck = true;
    void PauseGame()
    {
        if(timecheck == true)
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                Time.timeScale = 0f;
                timecheck = false;
            }
        }
        else if (timecheck == false)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Time.timeScale = 1f;
                timecheck = true;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        PauseGame();
    }
}
