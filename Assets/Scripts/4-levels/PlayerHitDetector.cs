using UnityEngine;

public class PlayerHitDetector : MonoBehaviour
{
    [SerializeField] string enemyTag = "Enemy";
    [SerializeField] LifeManager lifeManager;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag(enemyTag)) return;

        if (lifeManager != null)
        {
            lifeManager.PlayerGotHit();
        }
        else
        {
            Debug.LogWarning("PlayerHitDetector: LifeManager not assigned!");
        }

        // Always destroy the enemy that hit the player
        Destroy(other.gameObject);
    }
}
