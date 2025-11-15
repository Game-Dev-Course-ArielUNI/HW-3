using UnityEngine;

public class PlayerHitHandler : MonoBehaviour
{
    [Tooltip("Tag of the enemies that can hurt the player")]
    public string enemyTag = "Enemy";

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Only react to enemies
        if (!other.CompareTag(enemyTag))
            return;

        // Lose one life
        GAME_STATUS.playerLives--;
        Debug.Log("Player hit! Lives left: " + GAME_STATUS.playerLives);

        // Destroy the enemy that hit us
        Destroy(other.gameObject);

        // If no lives left -> game over
        if (GAME_STATUS.playerLives <= 0)
        {
            Debug.Log("Game Over!");
            Destroy(gameObject);   // destroy the player ship
            Time.timeScale = 0f;   // pause the game (simple game over)
        }
    }
}
