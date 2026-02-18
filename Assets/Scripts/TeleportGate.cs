using UnityEngine;
using TMPro;

public class TeleportGate : MonoBehaviour
{
    public Transform destination;
    public TextMeshProUGUI textDisplay;
    public string gateMessage = "";
    public float displayDuration = 3.0f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // 1. Get the CharacterController component
            CharacterController cc = other.GetComponent<CharacterController>();

            if (cc != null)
            {
                cc.enabled = false;
                other.transform.position = destination.position;
                cc.enabled = true;
            }
            else
            {
                other.transform.position = destination.position;
            }

            if (textDisplay != null)
            {
                textDisplay.text = gateMessage;
                textDisplay.gameObject.SetActive(true);
                CancelInvoke("HideMessage");
                Invoke("HideMessage", displayDuration);
            }
        }
    }

    void HideMessage()
    {
        textDisplay.gameObject.SetActive(false);
    }
}