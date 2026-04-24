using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Handles first-person player movement, camera look, and interaction system
/// for the VR Farm environment (PC-based prototype).
/// 
/// Responsibilities:
/// - Character movement using CharacterController
/// - Mouse-based camera rotation
/// - Raycast-based interaction system
/// - Triggering interactable objects (e.g., ChickenSound)
/// </summary>

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;
    private PlayerControls controls;

    private Vector2 moveInput;
    private Vector2 lookInput;

    [Header("Movement")]
    public float speed = 10f;

    [Header("Camera")]
    public float mouseSensitivity = 2f;
    private float xRotation = 0f;

    [Header("Interaction")]
    public float interactDistance = 15f;

    /// <summary>
    /// Initializes input system and required components.
    /// Binds movement and look input callbacks.
    /// </summary>
    void Awake()
    {
        controller = GetComponent<CharacterController>();
        controls = new PlayerControls();

        controls.Player.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        controls.Player.Move.canceled += ctx => moveInput = Vector2.zero;

        controls.Player.Look.performed += ctx => lookInput = ctx.ReadValue<Vector2>();
        controls.Player.Look.canceled += ctx => lookInput = Vector2.zero;
    }

    void OnEnable() => controls.Enable();
    void OnDisable() => controls.Disable();

    /// <summary>
    /// Main update loop handling movement, camera rotation, and interaction input.
    /// </summary>
    void Update()
    {
        HandleMovement();
        HandleMouseLook();

        // Interaction trigger (mouse click)
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            TryInteract();
        }
    }

    /// <summary>
    /// Moves the player using CharacterController based on input direction.
    /// </summary>
    void HandleMovement()
    {
        Vector3 move = transform.right * moveInput.x + transform.forward * moveInput.y;
        controller.Move(move * speed * Time.deltaTime);
    }

    /// <summary>
    /// Handles first-person camera rotation using mouse input.
    /// Vertical rotation is clamped to prevent full flipping.
    /// </summary>
    void HandleMouseLook()
    {
        Camera cam = Camera.main;
        if (cam == null) return;

        xRotation -= lookInput.y * mouseSensitivity;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        cam.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * lookInput.x * mouseSensitivity);
    }

    /// <summary>
    /// Performs a raycast from screen center to detect interactable objects.
    /// If a ChickenSound component is detected, triggers its audio response.
    /// </summary>
    void TryInteract()
    {
        Camera cam = Camera.main;
        if (cam == null) return;

        Vector2 center = new Vector2(Screen.width / 2f, Screen.height / 2f);
        Ray ray = cam.ScreenPointToRay(center);

        if (Physics.Raycast(ray, out RaycastHit hit, interactDistance))
        {
            ChickenSound chicken = hit.collider.GetComponentInParent<ChickenSound>();

            if (chicken != null)
            {
                chicken.PlayCluck();
            }
        }
    }
}
