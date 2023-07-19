using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Setup")]
    public Transform PlayerBody = null;
    public Camera PlayerCamera = null;
    [Header("Settings")]
    public float MouseSensitivity = 100f;
    public bool IsInvertedMouse = false;

    private float _xRotation = 0f;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        // getting inputs * add sensitivity * not lock to fps
        float mouseX = Input.GetAxis("Mouse X") * MouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * MouseSensitivity * Time.deltaTime;

        if (IsInvertedMouse)
        {
            // invert controls
            _xRotation += mouseY;
        }
        else
        {
            // normal look
            _xRotation -= mouseY;
        }

        // clamp value to a max angle
        _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);
        
        // rotate up down / X
        PlayerCamera.transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
        // rotate left right / Y
        PlayerBody.Rotate(Vector3.up * mouseX);
    }
}