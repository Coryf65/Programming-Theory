using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float MouseSensitivity = 100f;
    public Transform Player = null;

    private float _rotationX = 0f;

    private void Start()
    {
        // prevents seeing the cursor
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * MouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * MouseSensitivity * Time.deltaTime;
        
        // reverse the y to be normal
        _rotationX -= mouseY;
        // prevents moving to far on x
        _rotationX = Mathf.Clamp(_rotationX, -90f, 90f);
        
        transform.localRotation = Quaternion.Euler(_rotationX, 0f, 0f);
        // up and down
        Player.Rotate(Vector3.up * mouseX);
    }
}
