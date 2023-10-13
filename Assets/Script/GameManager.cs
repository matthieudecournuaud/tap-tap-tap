 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverCanvas;
    public GameObject MenuCanvas;

    private void Start()
    {
        gameOverCanvas.SetActive(false);
        Time.timeScale = 1;
        MenuCanvas.SetActive(false);
        Time.timeScale = 1;
    }

    public void GameOver() {
        gameOverCanvas.SetActive(true);
        Time.timeScale = 0;
        MenuCanvas.SetActive(true);
        Time.timeScale = 0;

    }

    public void Replay()
    {
        SceneManager.LoadScene(0);
    }

    public void Menuing()
    {
        SceneManager.LoadScene(1);
    }

    public void Agree()
    {
        SceneManager.LoadScene(0);
    }

}
