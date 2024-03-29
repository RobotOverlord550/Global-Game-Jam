using GONet;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Stick : GONetBehaviour
{
    [SerializeField] Rigidbody2D _rb;
    [SerializeField] float rotDampTime;
    [SerializeField] float rotDampSpeed;

    Camera _camera;
    float av = 0;
    PInput _pInput;

    private void Awake()
    {
        _pInput = new PInput();
        _camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
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
        if (GetComponent<GONetParticipant>().IsMine)
        {
            Vector2 mousePosition = _pInput.Player.Mouse.ReadValue<Vector2>();
            Vector3 mouseWorldPosition = _camera.ScreenToWorldPoint(mousePosition);
            Vector3 direction = mouseWorldPosition - transform.position;
            direction.z = 0f;

            if (direction.magnitude > 0.1f)
            {
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                _rb.MoveRotation(Mathf.SmoothDampAngle(_rb.rotation, angle, ref av, rotDampTime, rotDampSpeed));
            }
        }
    }
}
