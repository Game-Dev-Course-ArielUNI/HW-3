using UnityEngine;

public class HeartAppear : MonoBehaviour
{
    [SerializeField] private GameObject life; // The prefab to spawn
    [SerializeField][Tooltip("The minimum time for the life to appear")] private float minimumSpawnTime = 0f; // Minimum spawn interval
    [SerializeField][Tooltip("The maximum time for the life to appear")] private float maximumSpawnTime = 2f; // Maximum spawn interval
    [SerializeField][Tooltip("The range for random X positions")] private float randomXRange = 5f; // Horizontal range for spawning
    [SerializeField][Tooltip("The range for random Y positions")] private float randomYRange = 3f; // Vertical range for spawning

    private float timeUntilSpwan; // Countdown timer for the next spawn

    void Start()
    {
        // Initialize the time until the first spawn
        SetTimeSpwan();
    }

    void Update()
    {
        // Decrease the spawn timer
        timeUntilSpwan -= Time.deltaTime;

        // If the timer reaches zero, spawn a life and reset the timer
        if (timeUntilSpwan <= 0)
        {
            SpawnLife();
            SetTimeSpwan(); // Reset the spawn timer
        }
    }

    private void SpawnLife()
    {
        // Generate a random position within the specified range
        float randomX = transform.position.x + Random.Range(-randomXRange, randomXRange);
        float randomY = transform.position.y + Random.Range(-randomYRange, randomYRange);
        Vector3 randomPosition = new Vector3(randomX, randomY, transform.position.z);

        // Instantiate the life at the random position
        Instantiate(life, randomPosition, Quaternion.identity);
    }

    // Randomly sets the time until the next spawn between the minimum and maximum values
    private void SetTimeSpwan()
    {
        timeUntilSpwan = Random.Range(minimumSpawnTime, maximumSpawnTime);
    }
}
