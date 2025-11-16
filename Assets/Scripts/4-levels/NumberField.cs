using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class NumberField : MonoBehaviour
{
    private int number;
    private TextMeshProUGUI tmp;

    private void Awake()
    {
        tmp = GetComponent<TextMeshProUGUI>();
    }

    public int GetNumber()
    {
        return this.number;
    }

    public void SetNumber(int newNumber)
    {
        this.number = newNumber;
        tmp.text = newNumber.ToString();
    }

    public void AddNumber(int toAdd)
    {
        SetNumber(this.number + toAdd);
    }
}
