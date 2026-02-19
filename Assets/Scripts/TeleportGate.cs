using UnityEngine;
using TMPro;

public class TeleportGate : MonoBehaviour
{
    public Transform destination;
    public TextMeshProUGUI textDisplay;
    public string gateMessage = "";
    public float displayDuration = 3.0f;

    public bool resetRoom1OnTeleport = false;
    public GameObject Gate1;
    public GameObject lockManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
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

            if (resetRoom1OnTeleport)
            {
                ResetRoom1();
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

    void ResetRoom1()
    {
        if (Gate1 != null) Gate1.SetActive(false);

        if (lockManager != null)
        {
            lockManager.SendMessage("Start", SendMessageOptions.DontRequireReceiver);
        }
    }

    void HideMessage()
    {
        textDisplay.gameObject.SetActive(false);
    }
}