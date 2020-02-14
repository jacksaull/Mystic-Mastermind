using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public Transform playerBody; //The transform component for the Player
    public float mouseSensitivity = 100f; //How sensitive the mouse movement is
    float xRotation = 0f; //Mouse rotation

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; //Locks the mouse to the center of the screen
    }

    void Update()
    {
        /*Gets the input from movement of the mouse on the X and Y Axis and multiplies it by the mouse sensitivity and delta time so it is not independent of framerate*/
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        /*Movement of the mouse adjusts the camera on the Y Axis, and clamps it so you can not look too high up or too far down*/
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        /*Adjusts the rotation of the Player based on mouse movement on the X Axis*/
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
