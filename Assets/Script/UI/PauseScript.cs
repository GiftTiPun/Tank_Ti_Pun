using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    bool timecheck = true;
    public GameObject PauseText;
    void PauseGame()
    {
        if(timecheck == true)
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                Time.timeScale = 0f;
                PauseText.SetActive(true);
                timecheck = false;
            }
        }
        else if (timecheck == false)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Time.timeScale = 1f;
                PauseText.SetActive(false);
                timecheck = true;
            }
        }
    }

    private void Start()
    {
        PauseText.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        PauseGame();
    }
}
