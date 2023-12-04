using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipesSpawner : MonoBehaviour
{
    public float maxTime = 2;
    private float timer = 0;
    public GameObject pipe;
    public float height;

    private bool gameIsPaused = false; // Variable qui vérifie si le jeu est en pause

    private void Start()
    {
        // s'inscrire à l'événement de mise en pause du jeu
        GameManager.Instance.OnGamePaused += HandleGamePaused;
    }

    private void OnDestroy()
    {
        // Se désinscrire de l'événement lorsque l'objet est détruit
        GameManager.Instance.OnGamePaused -= HandleGamePaused;
    }

    private void HandleGamePaused(bool isPaused)
    {
        // Mettre à jour l'état du jeu lorsqu'il est en pause ou en reprise
        gameIsPaused = isPaused;
    }

    private void Update()
    {
        if (!gameIsPaused) // Vérifier si le jeu n'est pas en pause
        {
            if (timer > maxTime)
            {
                GameObject newPipe = Instantiate(pipe);
                newPipe.transform.position = transform.position + new Vector3(0, Random.Range(-height, height), 0);
                Destroy(newPipe, 10);
                timer = 0;
            }

            timer += Time.deltaTime;
        }
    }
}
