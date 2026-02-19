using UnityEngine;

public class NumberLockManager : MonoBehaviour
{
    public int[] correctCode = new int[3];
    public int[] currentInput = { 0, 0, 0 };
    public GameObject targetObject;
    public bool activateObject = false;
    public bool randomizeCode = true;
    public NumberLockManager originalManager;
    public CarrotDigitDisplay[] visualDisplays;

    void Start()
    {
        if (originalManager != null)
        {
            correctCode = originalManager.correctCode;
        }
        else if (randomizeCode)
        {
            for (int i = 0; i < correctCode.Length; i++)
            {
                correctCode[i] = Random.Range(0, 10);
                if (visualDisplays.Length > i)
                {
                    visualDisplays[i].DisplayNumber(correctCode[i]);
                }
            }
        }
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
            if (targetObject != null)
            {
                targetObject.SetActive(activateObject);
            }
        }
    }
}