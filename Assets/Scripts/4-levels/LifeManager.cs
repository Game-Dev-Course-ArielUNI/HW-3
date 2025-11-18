using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LifeManager : MonoBehaviour
{
    [Header("UI hearts (left to right)")]
    [SerializeField] private Image[] heartImages;

    [Header("Should lives reset to 3 when this scene starts?")]
    [SerializeField] private bool resetLivesOnSceneStart = false;

    private void Awake()
    {
        // For level 1: reset to 3 lives.
        // For level 2,keep whatever we had from previous level.
        if (resetLivesOnSceneStart)
        {
            PlayerLives.ResetLives();
        }

        UpdateHeartsUI();
    }

    
    public void PlayerGotHit()
    {
        if (CameraShake.Instance != null)
            CameraShake.Instance.Shake();

        PlayerLives.CurrentLives--;

        if (PlayerLives.CurrentLives < 0)
            PlayerLives.CurrentLives = 0;

        UpdateHeartsUI();

        if (PlayerLives.CurrentLives <= 0)
        {
            // After 3 hits (0 lives) → go to game-over scene
            SceneManager.LoadScene("level-game-over");
        }
    }

    private void UpdateHeartsUI()
    {
        if (heartImages == null) return;

        for (int i = 0; i < heartImages.Length; i++)
        {
            if (heartImages[i] == null) continue;

            // Show hearts only up to CurrentLives
            heartImages[i].enabled = (i < PlayerLives.CurrentLives);
        }
    }
}
