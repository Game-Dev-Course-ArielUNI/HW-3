using UnityEngine;

public static class ScreenUtils
{
    /// <summary>
    /// Returns a world position just above the top of the screen.
    /// xViewport = 0.0 left, 0.5 center, 1.0 right
    /// extra = how far above the screen
    /// </summary>
    public static Vector3 GetAboveTopScreenPosition(float xViewport = 0.5f, float extra = 0.1f)
    {
        // viewport: X between 0–1, Y > 1 means above the screen
        Vector3 vp = new Vector3(xViewport, 1f + extra, 0f);

        // convert viewport → world
        Vector3 world = Camera.main.ViewportToWorldPoint(vp);

        // Always keep Z = 0 for 2D
        world.z = 0f;

        return world;
    }
}
