using UnityEngine;
using TMPro;

public class DigitButton : MonoBehaviour
{
    public NumberLockManager manager;
    public int digitIndex;
    public TextMeshProUGUI displayText;

    private void OnMouseDown()
    {
        manager.IncrementDigit(digitIndex);
        if (displayText != null)
        {
            displayText.text = manager.currentInput[digitIndex].ToString();
        }
    }
}