using UnityEngine;

public class MouseMovement : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    private InputSystem_Actions inputActions;

    float xRotation = 0f;
    float YRotation = 0f;

    void Awake()
    {
        inputActions = new InputSystem_Actions();
    }

    void OnEnable()
    {
        inputActions.Player.Enable();
    }

    void OnDisable()
    {
        inputActions.Player.Disable();
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        Vector3 angles = transform.localEulerAngles;
        xRotation = angles.x;
        YRotation = angles.y;
    }

    void Update()
    {
        // float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        // float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        float mouseX =  inputActions.Player.Look.ReadValue<Vector2>().x * mouseSensitivity * Time.deltaTime;
        // float mouseY = Mouse.current.delta.y.ReadValue() * mouseSensitivity * Time.deltaTime
        float mouseY =  inputActions.Player.Look.ReadValue<Vector2>().y * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        YRotation += mouseX;

        transform.localRotation = Quaternion.Euler(xRotation, YRotation, 0f);
    }

    // Add this method below Update()
    public void SetRotation(float x, float y)
    {
        xRotation = x;
        YRotation = y;
        transform.localRotation = Quaternion.Euler(xRotation, YRotation, 0f);
    }
}
