using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MenuPause : MonoBehaviour
{
    public GameObject pausedUi;

    public void Stop()
    {
        Time.timeScale = 0;
        pausedUi.SetActive(true);
    }


    public void Resume()
    {

        pausedUi.SetActive(false);
        Time.timeScale = 1;        

    }

   
}
