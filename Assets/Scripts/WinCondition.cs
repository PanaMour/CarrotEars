using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class WinCondition : MonoBehaviour
{
    public TextMeshProUGUI winText;
    public GameObject winPanel;
    public string message = "YOU REGAINED YOUR EARS!";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (winText != null)
            {
                winText.text = message;
                winText.gameObject.SetActive(true);
            }
            if (winPanel != null) winPanel.gameObject.SetActive(true);

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0;
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}