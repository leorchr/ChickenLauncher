using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;

public class LookWithMouse : MonoBehaviour
{
    public static LookWithMouse instance;

    const float k_MouseSensitivityMultiplier = 0.01f;

    [SerializeField] private PlayerInput playerInput;
    public float mouseSensitivity = 100f;
    public float gamepadSensitivity = 100f;

    public Transform playerBody;

    float xRotation = 0f;

    [SerializeField] private bool invertYAxis;
    [SerializeField][Range(-90.0f, 0)] private float minAngle = -90f;
    [SerializeField][Range(0, 90.0f)] private float maxAngle = 90f;

    private float mouseLock = 1f;

    void Awake()
    {
        if (instance) Destroy(this);
        else instance = this;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }


    void Update()
    {
        float mouseX = 0, mouseY = 0;

        if (Mouse.current != null)
        {
            var delta = Mouse.current.delta.ReadValue() / 15.0f;
            mouseX += delta.x;
            mouseY += delta.y;
        }
        if (Gamepad.current != null)
        {
            var value = Gamepad.current.rightStick.ReadValue() * 2;
            mouseX += value.x;
            mouseY += value.y;
        }

        if (playerInput.currentControlScheme == "Controller")
        {
            mouseX *= gamepadSensitivity * k_MouseSensitivityMultiplier;
            mouseY *= gamepadSensitivity * k_MouseSensitivityMultiplier;
        }
        else
        {
            mouseX *= mouseSensitivity * k_MouseSensitivityMultiplier;
            mouseY *= mouseSensitivity * k_MouseSensitivityMultiplier;
        }

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, minAngle, maxAngle);

        int invertAxis = invertYAxis ? -1 : 1;
        transform.localRotation = Quaternion.Euler(invertAxis*xRotation, 0f, 0f);

        playerBody.Rotate(Vector3.up * mouseX * mouseLock);
    }

    public void LockAndUnlockMouse()
    {
        if (mouseLock == 1f)
        {
            mouseLock = 0f;
        }
        else mouseLock = 1f;
    }
}
