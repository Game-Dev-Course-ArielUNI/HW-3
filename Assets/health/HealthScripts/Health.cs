using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    [Tooltip("this player Health when start the game ")]
    private float start_PlayerHealth;
    public float current_PlayerHealth { get; private set; }

    void Start()
    {
        current_PlayerHealth = start_PlayerHealth;
        
    }
    public void Take_Damge(float _damge)
    {
        current_PlayerHealth=Mathf.Clamp(current_PlayerHealth-_damge,0,start_PlayerHealth);
        
    }
    public void Add_Heart ()
    {
        if (current_PlayerHealth < 3) {
            current_PlayerHealth += 1f;
        }
        
    }
  

    // Update is called once per frame
    void Update()
    {
      if(current_PlayerHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
