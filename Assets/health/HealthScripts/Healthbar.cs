using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [SerializeField] private Health Player_Health;
    [SerializeField] private Image totalhealthbar;
    [SerializeField] private Image currenthealthbar;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        totalhealthbar.fillAmount = Player_Health.current_PlayerHealth / 10;//start with 3 health bar
    }

    // Update is called once per frame
    void Update()
    {
        currenthealthbar.fillAmount= Player_Health.current_PlayerHealth /10;

    }
    public void Add_HealthBar()
    {
        if (currenthealthbar.fillAmount < 0.3)
        {
            currenthealthbar.fillAmount += 1 / 10;
        }
    }
}
