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
        gameManager.GameOver();
    }
}
