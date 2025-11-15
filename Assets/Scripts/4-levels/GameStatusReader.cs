using UnityEngine;

[RequireComponent(typeof(NumberField))]
public class GameStatusReader : MonoBehaviour
{
    private NumberField numberField;

    void Awake()
    {
        numberField = GetComponent<NumberField>();
    }

    void Update()
    {
        numberField.SetNumber(GAME_STATUS.playerScore);
    }
}
