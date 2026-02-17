using UnityEngine;

public class LockButton : MonoBehaviour
{
    public NumberLock lockScript;
    public int digitIndex;

    private void OnMouseDown()
    {
        lockScript.ChangeDigit(digitIndex);
        transform.localScale = Vector3.one * 1.2f; // Visual feedback
        Invoke("ResetScale", 0.1f);
    }

    void ResetScale() { transform.localScale = Vector3.one; }
}