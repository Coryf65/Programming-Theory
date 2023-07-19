using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Setup")]
    public CharacterController Controller;
    [Tooltip("Layer that indicates the Ground. That layer must be attached to walkable objects.")]
    public LayerMask GroundLayer;
    [Tooltip("Players ground check, a position at the feet of the player.")]
    public Transform GroundCheck;
    [Header("Settings")]
    public float Speed = 12f;
    public float JumpHeight= 2f;
    public float GroundDistance = 0.4f;
    [Range(-20, 0)]
    public float FallingSpeed = -2f;
    [Header("Info")]
    public bool IsGrounded;

    private Vector3 _velocity;
    private readonly float _gravity = -9.81f; // 9.81 meters2, earths gravity
    private float _doubleGravity = -2f;
    
    private void Start()
    {
        gameObject.AddComponent<CharacterController>();
        Controller = gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        IsGrounded = CheckIfOnGround();

        // add a falling speed
        if (IsGrounded && _velocity.y < 0)
        {
            _velocity.y = FallingSpeed;
        }

        if (Input.GetButtonDown("Jump") && IsGrounded)
        {
            HandleJumping();
        }
        HandlePlayerMovement();
    }

    /// <summary>
    /// Control the player using WASD movement.
    /// </summary>
    private void HandlePlayerMovement()
    {
        // left right / a + d
        float x = Input.GetAxis("Horizontal");
        // forward backwards / w + s
        float z = Input.GetAxis("Vertical");

        // handles movement
        Vector3 movement = transform.right * x + transform.forward * z;
        Controller.Move(movement * Time.deltaTime * Speed);
        
        // adding gravity
        _velocity.y += _gravity * Time.deltaTime;
        
        // add gravity to the player
        Controller.Move(_velocity * Time.deltaTime);
    }
    
    /// <summary>
    /// Handle player jumping
    /// </summary>
    private void HandleJumping()
    {
        _velocity.y = Mathf.Sqrt(JumpHeight * _doubleGravity * _gravity);
    }

    private bool CheckIfOnGround()
    {
        return Physics.CheckSphere(GroundCheck.position, GroundDistance, GroundLayer);
    }
}