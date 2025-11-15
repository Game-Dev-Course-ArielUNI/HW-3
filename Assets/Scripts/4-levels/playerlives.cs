using UnityEngine;
using UnityEngine.UI;

public class PlayerLivesUI : MonoBehaviour
{
    public Image heart1;
    public Image heart2;
    public Image heart3;

    void Update()
    {
        // Reset all hearts to visible
        heart1.enabled = GAME_STATUS.playerLives >= 1;
        heart2.enabled = GAME_STATUS.playerLives >= 2;
        heart3.enabled = GAME_STATUS.playerLives >= 3;
    }
}
