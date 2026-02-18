using UnityEngine;

public class HoppyController : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float hopSpeed = 10.0f;
    public float hopHeight = 0.5f;
    public float gravity = 20.0f;
    public AudioClip hop;

    private CharacterController controller;
    private AudioSource audioSource;
    private float timer = 0;
    private Transform meshChild;
    private Vector3 velocity;
    private bool hasHoppedInCycle = false;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
        audioSource.clip = hop;

        if (transform.childCount > 0) meshChild = transform.GetChild(0);
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        Vector3 move = transform.right * moveX + transform.forward * moveZ;

        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        controller.Move(move * moveSpeed * Time.deltaTime);
        velocity.y -= gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        if (move.magnitude > 0.1f)
        {
            timer += Time.deltaTime * hopSpeed;
            float sinePos = Mathf.Sin(timer);
            float newY = Mathf.Abs(sinePos) * hopHeight;

            if (meshChild != null) meshChild.localPosition = new Vector3(0, newY, 0);

            if (sinePos > 0.1f && !hasHoppedInCycle)
            {
                audioSource.PlayOneShot(hop);
                hasHoppedInCycle = true;
            }
            else if (sinePos < -0.1f || (sinePos > -0.1f && sinePos < 0.1f && hasHoppedInCycle && timer % (Mathf.PI) < 0.5f))
            {
                if (newY < 0.05f) hasHoppedInCycle = false;
            }
        }
        else
        {
            timer = 0;
            hasHoppedInCycle = false;
            if (meshChild != null) meshChild.localPosition = Vector3.Lerp(meshChild.localPosition, Vector3.zero, Time.deltaTime * 10f);
        }
    }
}