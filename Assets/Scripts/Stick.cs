using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Stick : MonoBehaviour
{
    [SerializeField] Camera _camera;
    [SerializeField] Rigidbody2D _rb;

    float av = 0;
    PInput _pInput;
    
    private void Awake()
    {
        _pInput = new PInput();
    }

    private void OnEnable()
    {
        _pInput.Player.Enable();
    }

    private void OnDisable()
    {
        _pInput.Player.Disable();
    }

    void Update()
    {
        HandleStickMovement();
    }

    void HandleStickMovement()
    {
        Vector2 mousePosition = _pInput.Player.Mouse.ReadValue<Vector2>();
        Vector3 mouseWorldPosition = _camera.ScreenToWorldPoint(mousePosition);
        Vector3 direction = mouseWorldPosition - transform.position;
        direction.z = 0f; // Make sure z-component is zero since we're working in 2D

        if (direction.magnitude > 0.1f) // Check if mouse is not too close to the object to avoid division by zero
        {
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            _rb.MoveRotation(angle);
        }
    }
}
