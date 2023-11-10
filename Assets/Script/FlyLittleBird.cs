using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyLittleBird : MonoBehaviour
{
    public GameManager gameManager;
    public float jumpForce = 5f; // Force du saut de l'oiseau
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameManager = FindFirstObjectByType<GameManager>();

        if (gameManager == null)
        {
            Debug.LogError("GameManager not found in the scene.");
        }
    }

    void Update()
    {
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

}
