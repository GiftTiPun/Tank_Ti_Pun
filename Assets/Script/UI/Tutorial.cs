using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public GameObject Tutorial_1;
    public GameObject Tutorial_2;
    public GameObject Tutorial_3;
    public GameObject Tutorial_4;
    public GameObject LevelUi;
    public GameObject EnemySpawn;

    private void Start()
    {
        Tutorial_1.SetActive(true);
        Tutorial_2.SetActive(false);
        Tutorial_3.SetActive(false);
        Tutorial_4.SetActive(false);
        LevelUi.SetActive(false);

    }
    public void DestroyTutorial(GameObject tutorial)
    {
        Destroy(tutorial);
    }

    public void ActiveNext(GameObject tutorial)
    {
        tutorial.SetActive(true);
        if(tutorial.name == "Level1_UI")
        {
            EnemySpawn.SetActive(true);
        }
    }
}
