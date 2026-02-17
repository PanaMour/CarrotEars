using UnityEngine;

public class TeleportGate : MonoBehaviour
{
    [Tooltip("Place an empty GameObject where you want the player to land")]
    public Transform teleportTarget;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.position = teleportTarget.position;
            Physics.SyncTransforms();

            Debug.Log("Rabbit has entered a Strange Place!");
        }
    }
}