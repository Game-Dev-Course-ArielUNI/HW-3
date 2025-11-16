using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This component destroys its object whenever it triggers a 2D collider with the given tag.
 * Now includes a flag to control whether hitting triggers the onHit event (player death).
 */
public class DestroyOnTrigger2D : MonoBehaviour
{
    [Tooltip("Every object tagged with this tag will trigger the destruction of both objects")]
    [SerializeField] string triggeringTag;

    [Tooltip("Does this collision represent the player being hit? (If yes → game over event fires)")]
    public bool triggerGameOver = false;

    public event System.Action onHit;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == triggeringTag && enabled)
        {

            // Increase score if this is an enemy being destroyed
            if (!triggerGameOver)
            {
                GAME_STATUS.playerScore += 1;
            }

            // Destroy both game objects
            Destroy(this.gameObject);
            Destroy(other.gameObject);

            // If this collision is supposed to cause "game over", only then call the event
            if (triggerGameOver)
            {
                onHit?.Invoke();
            }
        }
    }

    private void Update() { }
}
