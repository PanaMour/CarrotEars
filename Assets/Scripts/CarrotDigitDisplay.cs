using UnityEngine;

public class CarrotDigitDisplay : MonoBehaviour
{
    public GameObject[] segments;

    private readonly bool[][] numberPatterns = new bool[][]
    {
        new bool[] {true, true, true, true, true, true, false},   // 0
        new bool[] {false, true, true, false, false, false, false}, // 1
        new bool[] {true, true, false, true, true, false, true},  // 2
        new bool[] {true, true, true, true, false, false, true}, // 3
        new bool[] {false, true, true, false, false, true, true}, // 4
        new bool[] {true, false, true, true, false, true, true},  // 5
        new bool[] {true, false, true, true, true, true, true},   // 6
        new bool[] {true, true, true, false, false, false, false}, // 7
        new bool[] {true, true, true, true, true, true, true},    // 8
        new bool[] {true, true, true, true, false, true, true}    // 9
    };

    public void DisplayNumber(int number)
    {
        if (number < 0 || number > 9) return;
        for (int i = 0; i < segments.Length; i++)
        {
            segments[i].SetActive(numberPatterns[number][i]);
        }
    }
}