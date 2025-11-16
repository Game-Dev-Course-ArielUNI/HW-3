using UnityEngine;
using TMPro; // only if you want to show text

public class LifeManager : MonoBehaviour
{
    public static LifeManager Instance;

    [Header("Player Lives")]
    [SerializeField] private int maxLives = 3;
    [SerializeField] private int currentLives;

    [Header("UI")]
    public GameObject[] hearts;
    // assign 3 heart images in Inspector

    private void Awake()
    {
        Instance = this;
        currentLives = maxLives;
        UpdateHeartsUI();
    }

    public void PlayerHit()
    {

        currentLives--;

        Debug.Log("PlayerHit() called! Lives now = " + currentLives);


        UpdateHeartsUI();

        if (currentLives <= 0)
        {
            GameOver();
        }
        else
        {
            RespawnPlayer();
        }
    }
    public int GetLives()
    {
        return currentLives;
    }


    private void RespawnPlayer()
    {
        // simple respawn: reset position
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
            player.transform.position = new Vector3(0, -3, 0);
    }

    private void UpdateHeartsUI()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].SetActive(i < currentLives);
        }
    }

    private void GameOver()
    {
        Debug.Log("GAME OVER");
        Time.timeScale = 0f;
    }
}
