using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float MouseSensitivityX = 100f;
    public float MouseSensitivityY = 100f;
    public Transform Player = null;

    private float _rotationX = 0f;
    private float _rotationY = 0f;

    private void Start()
    {
        // prevents seeing the cursor
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        HandleCameraMovement();
    }

    private void HandleCameraMovement()
    {
        float mouseX = Input.GetAxis("Mouse X") * MouseSensitivityX * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * MouseSensitivityY * Time.deltaTime;
        
        // reverse the y to be normal
        _rotationY -= mouseX;
        _rotationX -= mouseY;
        // prevents moving to far on x
        _rotationX = Mathf.Clamp(_rotationX, -90f, 90f);
        
        // rotate
        transform.localRotation = Quaternion.Euler(_rotationX, 0f, 0f);
        // up and down
        Player.Rotate(Vector3.up * mouseX);
        
        // other way
        // transform.rotation = Quaternion.Euler(_rotationX, _rotationY, 0f);
        // Player.rotation = Quaternion.Euler(0f, _rotationY, 0f);
    }
}
