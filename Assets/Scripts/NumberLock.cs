using UnityEngine;

public class NumberLock : MonoBehaviour
{
    public int[] currentNumbers = { 0, 0, 0 };
    public int[] correctCode = { 3, 2, 1 };
    public GameObject gate;

    public void ChangeDigit(int index)
    {
        currentNumbers[index]++;
        if (currentNumbers[index] > 9) currentNumbers[index] = 0;

        Debug.Log("Digit " + index + " is now: " + currentNumbers[index]);
        CheckCode();
    }

    void CheckCode()
    {
        if (currentNumbers[0] == correctCode[0] &&
            currentNumbers[1] == correctCode[1] &&
            currentNumbers[2] == correctCode[2])
        {
            gate.SetActive(false);
            Debug.Log("Lock Unlocked!");
        }
    }
}