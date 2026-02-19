using UnityEngine;

public class RedLightGreenLight : MonoBehaviour
{
    public CharacterController playerController;
    public Transform failDestination;
    public bool isRedLight = false;
    public Light roomLight;
    private float timer = 0f;
    public float vel = 0.0000001f;
    private bool playerInside = false;

    void Update()
    {
        if (playerInside && Vector3.Distance(transform.position, playerController.transform.position) > 30f)
        {
            playerInside = false;
        }

        if (!playerInside) return;

        timer += Time.deltaTime;

        if (timer > 3f)
        {
            isRedLight = !isRedLight;
            timer = 0f;

            if (roomLight != null)
                roomLight.color = isRedLight ? Color.red : Color.green;
        }

        if (isRedLight && playerInside && playerController.velocity.magnitude > vel)
        {
            TeleportPlayer();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = false;
        }
    }

    void TeleportPlayer()
    {
        playerInside = false;
        playerController.enabled = false;
        playerController.transform.position = failDestination.position;
        playerController.enabled = true;
    }
}