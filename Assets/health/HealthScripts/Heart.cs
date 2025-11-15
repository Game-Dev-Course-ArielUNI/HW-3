using UnityEngine;

public class Heart : MonoBehaviour
{
    private Health health;
    private Healthbar healthbar;

    private void Awake()
    {
        // Find required components
        health = FindAnyObjectByType<Health>();
        healthbar = FindAnyObjectByType<Healthbar>();

        if (health == null)
        {
            Debug.LogError("Health component not found in the scene!");
        }

        if (healthbar == null)
        {
            Debug.LogError("Healthbar component not found in the scene!");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the object colliding is the Player
        if (collision.gameObject.tag == "Player" && enabled)
        {
            if (health != null)
            {
                health.Add_Heart(); // Add a heart to the player's health
            }

            if (healthbar != null)
            {
                healthbar.Add_HealthBar(); // Update the health bar UI
            }

            // Destroy the heart object
            Destroy(gameObject);
        }
    }
}
