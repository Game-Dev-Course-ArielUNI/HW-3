using UnityEngine;

public class EnemyHurt : MonoBehaviour
{
    [SerializeField] private float damge;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Health>().Take_Damge(damge);
        }
        
    }


}
