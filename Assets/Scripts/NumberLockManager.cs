using UnityEngine;

public class NumberLockManager : MonoBehaviour
{
    public int[] correctCode = new int[3];
    public int[] currentInput = { 0, 0, 0 };
    public GameObject gate;
    public CarrotDigitDisplay[] visualDisplays;

    void Start()
    {
        for (int i = 0; i < correctCode.Length; i++)
        {
            correctCode[i] = Random.Range(0, 10);
            if (visualDisplays.Length > i)
            {
                visualDisplays[i].DisplayNumber(correctCode[i]);
            }
        }
        Debug.Log("The secret code is: " + correctCode[0] + correctCode[1] + correctCode[2]);
    }

    public void IncrementDigit(int index)
    {
        currentInput[index]++;
        if (currentInput[index] > 9) currentInput[index] = 0;
        CheckCode();
    }

    void CheckCode()
    {
        if (currentInput[0] == correctCode[0] &&
            currentInput[1] == correctCode[1] &&
            currentInput[2] == correctCode[2])
        {
            Debug.Log("PUZZLE COMPLETE!");
            if (gate != null) gate.SetActive(true);
        }
    }
}