using UnityEngine;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

public class MouseHide : MonoBehaviour
{
    public float mouseSensitivity = 200f;
    public Transform playerBody;

    public GameObject illustratePanel;
    public GameObject SettingPanel;

    private float xRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        bool isAltHeld = Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt);
        bool isTabActive = illustratePanel.activeSelf;
        bool isSetActive = SettingPanel.activeSelf;

        if (isAltHeld || isTabActive||isSetActive)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Debug.Log("LockState = " + Cursor.lockState);
            return;
        }

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        float mouseX;
        float mouseY;

#if ENABLE_INPUT_SYSTEM
        mouseX = Mouse.current.delta.x.ReadValue() * mouseSensitivity * Time.deltaTime;
        mouseY = Mouse.current.delta.y.ReadValue() * mouseSensitivity * Time.deltaTime;
#else
        mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
#endif

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
