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
        // For level 2, 3...: keep whatever we had from previous level.
        if (resetLivesOnSceneStart)
        {
            PlayerLives.ResetLives();
        }

        UpdateHeartsUI();
    }

    /// <summary>
    /// Called by PlayerHitDetector whenever the player gets hit by an enemy.
    /// </summary>
    public void PlayerGotHit()
    {
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














//using UnityEngine;
//using UnityEngine.UI;
//using UnityEngine.SceneManagement;

//public class LifeManager : MonoBehaviour
//{
//    [Header("Lives")]
//    [SerializeField] int maxLives = 3;

//    [Header("UI hearts (from left to right)")]
//    [SerializeField] Image[] heartImages;

//    private int currentLives;

//    private void Awake()
//    {
//        currentLives = maxLives;
//        UpdateHeartsUI();
//    }

//    /// <summary>
//    /// Call this when the player is hit by an enemy.
//    /// Returns true if player is still alive, false if game over.
//    /// </summary>
//    public bool PlayerGotHit()
//    {
//        currentLives--;
//        UpdateHeartsUI();

//        if (currentLives <= 0)
//        {
//            // Game over: reload scene (you can change this later)
//            Scene current = SceneManager.GetActiveScene();
//            SceneManager.LoadScene(current.buildIndex);
//            return false;
//        }

//        return true;
//    }

//    private void UpdateHeartsUI()
//    {
//        if (heartImages == null)
//            return;

//        for (int i = 0; i < heartImages.Length; i++)
//        {
//            bool shouldBeVisible = (i < currentLives);
//            if (heartImages[i] != null)
//            {
//                heartImages[i].enabled = shouldBeVisible;
//            }
//        }
//    }
//}
