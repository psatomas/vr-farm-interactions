using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;
    private PlayerControls controls;
    private Vector2 moveInput;
    private Vector2 lookInput;

    public float speed = 10f;
    public float mouseSensitivity = 2f;
    private float xRotation = 0f;

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
    void Start()
    {
        Debug.Log("START WORKS");
    }

void Update()
{
    HandleMovement();
    HandleMouseLook();

    if (Keyboard.current.eKey.wasPressedThisFrame ||
        Mouse.current.leftButton.wasPressedThisFrame)
    {
        TryInteract();
    }
}

    void HandleMovement()
    {
        Vector3 move = transform.right * moveInput.x + transform.forward * moveInput.y;
        controller.Move(move * speed * Time.deltaTime);
    }

    void HandleMouseLook()
    {
        xRotation -= lookInput.y * mouseSensitivity;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        Camera.main.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * lookInput.x * mouseSensitivity);
    }

    // 👇 ADD THIS METHOD
    void TryInteract()
    {
        Debug.Log("Interact triggered");

        Camera cam = Camera.main;
        if (cam == null)
        {
            Debug.LogError("No Main Camera found!");
            return;
        }

        Ray ray = cam.ScreenPointToRay(Mouse.current.position.ReadValue());

        if (Physics.Raycast(ray, out RaycastHit hit, 5f))
        {
            Debug.Log("Hit: " + hit.collider.name);

            ChickenSound chicken = hit.collider.GetComponentInParent<ChickenSound>();

            if (chicken != null)
            {
                Debug.Log("Chicken detected → playing sound");
                chicken.PlayCluck();
            }
            else
            {
                Debug.Log("Hit object is not chicken");
            }
        }
        else
        {
            Debug.Log("Nothing hit");
        }
    }
}

