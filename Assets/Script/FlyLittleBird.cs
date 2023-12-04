using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FlyLittleBird : MonoBehaviour
{
    public GameManager gameManager;
    public float jumpForce = 5f; // Force du saut de l'oiseau
    private Rigidbody2D rb;
    public GameObject textToShow;
    private float currentTime = 0f;
    private float startTime = 3f;
    private bool isTimer = false;
    public TMP_Text timer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameManager = FindFirstObjectByType<GameManager>();

        if (gameManager == null)
        {
            Debug.LogError("GameManager not found in the scene.");
        }
        currentTime = startTime;

    }

    void Update()
    {
        textToShow.SetActive(true);

        // Vérifiez s'il y a un toucher sur l'écran
        if (Input.touchCount > 0)
        {
            // Récupérez le premier toucher (l'oiseau réagira au premier toucher seulement)
            Touch touch = Input.GetTouch(0);

            // Vérifiez si le toucher est de type "began" (commencé)
            if (touch.phase == TouchPhase.Began)
            {
                // Appliquez une force vers le haut pour faire voler l'oiseau
                rb.velocity = Vector2.up * jumpForce;
            }
        }
        

        // si le timer est à 0  on défreeze le joeur
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            timer.text = currentTime.ToString("0");
            FreezePlayerConstraints();

        }
        else
        {
            currentTime = 0; 
            textToShow.SetActive(false);
            UnfreezePlayerConstraints();
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameManager == null)
        {
            Debug.LogError("GameManager is not assigned in FlyLittleBird.");
            return;
        }

        gameManager.GameOver();
    }


    public void ResetBird()
    {
        rb.velocity = Vector2.zero; // Annule toute vitesse résiduelle
        transform.position = new Vector3(0, 0, 0); // Remet l'oiseau à sa position initiale ou à une position par défaut
    }


    // Défreeze le joueur
    private void UnfreezePlayerConstraints()
    {
        if (rb != null)
        {
            rb.constraints = RigidbodyConstraints2D.None;
        }
    }

    // Freeze le joueur
    private void FreezePlayerConstraints()
    {
        if (rb != null)
        {
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }

}
