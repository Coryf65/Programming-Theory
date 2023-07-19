using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Setup")]
    public CharacterController Controller;
    [Header("Settings")]
    public float Speed = 12f;

    private Vector3 _velocity;
    
    private void Start()
    {
        gameObject.AddComponent<CharacterController>();
        Controller = gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        // left right / a + d
        float x = Input.GetAxis("Horizontal");
        // forward backwards / w + s
        float z = Input.GetAxis("Vertical");

        Vector3 movement = transform.right * x + transform.forward * z;
        Controller.Move(movement * Time.deltaTime * Speed);
    }
}