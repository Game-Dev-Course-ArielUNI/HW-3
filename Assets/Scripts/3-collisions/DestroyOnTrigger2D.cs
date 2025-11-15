using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Handles collisions differently for the player and for other objects:
 *
 * - triggerGameOver = false  → e.g. capsule hits enemy:
 *     * score++
 *     * destroy both objects
 *
 * - triggerGameOver = true   → player hits enemy:
 *     * playerLives--
 *     * destroy enemy
 *     * if lives <= 0 → destroy player + call onHit (game over)
 */
public class DestroyOnTrigger2D : MonoBehaviour
{
    [Tooltip("Every object tagged with this tag will trigger this collision")]
    [SerializeField] string triggeringTag;

    [Tooltip("Enable this ONLY on the player ship")]
    public bool triggerGameOver = false;

    public event System.Action onHit;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!enabled || other.tag != triggeringTag)
            return;

        // 🟥 CASE 1 – PLAYER got hit (this script is on the player)
        if (triggerGameOver)
        {
            // lose one life
            GAME_STATUS.playerLives--;
            Debug.Log("Player hit! Lives left: " + GAME_STATUS.playerLives);

            // destroy ONLY the enemy
            Destroy(other.gameObject);

            // if no lives left → now game over
            if (GAME_STATUS.playerLives <= 0)
            {
                Destroy(this.gameObject);  // destroy the player
                onHit?.Invoke();           // level manager pauses / shows game over
            }

            // important: do NOT destroy the player if he still has lives
            return;
        }

        // 🟩 CASE 2 – normal collision (capsule hits enemy)
        GAME_STATUS.playerScore++;
        Debug.Log("Enemy destroyed, score: " + GAME_STATUS.playerScore);

        Destroy(this.gameObject);   // e.g. capsule
        Destroy(other.gameObject);  // enemy
    }

    private void Update() { }
}
































//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

///**
// * Handles collisions differently for the player and enemies.
// * - If triggerGameOver = false → normal collision (capsule hits enemy)
// * - If triggerGameOver = true → player collision (lose heart; die after 3 hits)
// */
//public class DestroyOnTrigger2D : MonoBehaviour
//{
//    [Tooltip("Every object tagged with this tag will trigger this collision")]
//    [SerializeField] string triggeringTag;

//    // TRUE only on the PLAYER object
//    public bool triggerGameOver = false;

//    public event System.Action onHit;

//    private void OnTriggerEnter2D(Collider2D other)
//    {
//        if (other.tag != triggeringTag || !enabled)
//            return;

//        // -----------------------------------------------------------
//        // CASE 1: PLAYER gets hit by enemy (triggerGameOver = true)
//        // -----------------------------------------------------------
//        if (triggerGameOver)
//        {
//            // Player loses 1 life
//            GAME_STATUS.playerLives--;

//            // Destroy ONLY the enemy
//            Destroy(other.gameObject);

//            // If no lives left → player dies
//            if (GAME_STATUS.playerLives <= 0)
//            {
//                Destroy(this.gameObject); // destroy the player
//                onHit?.Invoke();          // pause game / game over logic
//            }

//            // STOP HERE - do NOT destroy the player yet if lives remain
//            return;
//        }

//        // -----------------------------------------------------------
//        // CASE 2: Capsule hits enemy (triggerGameOver = false)
//        // -----------------------------------------------------------

//        // Score increases
//        GAME_STATUS.playerScore++;

//        // Destroy both capsule and enemy
//        Destroy(this.gameObject);
//        Destroy(other.gameObject);
//    }

//    private void Update() { }
//}









//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

///**
// * This component destroys its object whenever it triggers a 2D collider with the given tag.
// * Now includes a flag to control whether hitting triggers the onHit event (player death).
// */
//public class DestroyOnTrigger2D : MonoBehaviour
//{
//    [Tooltip("Every object tagged with this tag will trigger the destruction of both objects")]
//    [SerializeField] string triggeringTag;

//    [Tooltip("Does this collision represent the player being hit? (If yes → game over event fires)")]
//    public bool triggerGameOver = false;

//    public event System.Action onHit;

//    private void OnTriggerEnter2D(Collider2D other)
//    {
//        if (other.tag == triggeringTag && enabled)
//        {

//            // Increase score if this is an enemy being destroyed
//            if (!triggerGameOver)
//            {
//                GAME_STATUS.playerScore += 1;
//            }

//            // Destroy both game objects
//            Destroy(this.gameObject);
//            Destroy(other.gameObject);

//            // If this collision is supposed to cause "game over", only then call the event
//            if (triggerGameOver)
//            {
//                onHit?.Invoke();
//            }
//        }
//    }

//    private void Update() { }
//}




















































////using System.Collections;
////using System.Collections.Generic;
////using UnityEngine;

/////**
//// * This component destroys its object whenever it triggers a 2D collider with the given tag.
//// */
////public class DestroyOnTrigger2D : MonoBehaviour
////{
////    [Tooltip("Every object tagged with this tag will trigger the destruction of both objects")]
////    [SerializeField] string triggeringTag;

////    public event System.Action onHit;

////    private void OnTriggerEnter2D(Collider2D other)
////    {

////        // PLAYER HIT LOGIC
////        //if (other.CompareTag("Player"))
////        //{
////        //    LifeManager.Instance.PlayerHit();   // lose one heart
////        //    Destroy(this.gameObject);           // destroy enemy only
////        //    return;                             // do NOT destroy the player
////        //}

////        // REGULAR LOGIC (laser hits enemy, etc.)
////        if (other.tag == triggeringTag && enabled)
////        {
////            Destroy(this.gameObject);
////            Destroy(other.gameObject);
////            onHit?.Invoke();
////        }
////    }

////    private void Update()
////    {
////        /* Just to show the enabled checkbox in Editor */
////    }
////}
