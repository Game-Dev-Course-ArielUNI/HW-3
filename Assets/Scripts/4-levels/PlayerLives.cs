using UnityEngine;

public static class PlayerLives
{
    public const int MaxLives = 3;

    // The current lives (shared between all scenes)
    public static int CurrentLives = MaxLives;

    public static void ResetLives()
    {
        CurrentLives = MaxLives;
    }
}
