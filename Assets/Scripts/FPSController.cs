using UnityEngine;

public class SimpleFPSController : MonoBehaviour
{

    // Simple FPS controller script to handle player movement and mouse look
    // Movement speed of the player
    // Mouse sensitivity for looking around
    // Transform for the camera to apply pitch rotation
    public float moveSpeed = 5f;
    public float mouseSensitivity = 2f;
    public Transform cameraTransform;

    private CharacterController controller;
    private float pitch = 0f;


    // Start is called before the first frame update
    // Initialize the character controller and lock the cursor for FPS view
    // Set the cursor to be locked in the center of the screen
    // This prevents the cursor from leaving the game window
    void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    // Handle mouse look and player movement
    void Update()
    {
        // Mouse look
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        transform.Rotate(Vector3.up * mouseX);

        pitch -= mouseY;
        pitch = Mathf.Clamp(pitch, -90f, 90f);
        cameraTransform.localRotation = Quaternion.Euler(pitch, 0f, 0f);

        // Movement
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 move = transform.right * h + transform.forward * v;
        controller.Move(move * moveSpeed * Time.deltaTime);
    }
}
