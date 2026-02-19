using UnityEngine;

public class IntroButton : MonoBehaviour
{
    public GameObject introPanel;

    public void CloseIntro()
    {
        if (introPanel != null)
        {
            introPanel.SetActive(false);

        }
    }
}