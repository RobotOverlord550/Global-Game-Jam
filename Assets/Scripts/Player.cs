using GONet;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject Mouse;

    [SerializeField] Rigidbody2D _rb;
    [SerializeField] float _rotDampTime;
    [SerializeField] float _rotDampSpeed;
    [SerializeField] float jumpForce;

    float av = 0;
    void Update()
    {
        HandleStickMovement();
    }

    void HandleStickMovement()
    {
        Vector3 direction = Mouse.transform.position - transform.position;
        direction.z = 0f;

        if (direction.magnitude > 0.1f)
        {
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            _rb.MoveRotation(Mathf.SmoothDampAngle(_rb.rotation, angle, ref av, _rotDampTime, _rotDampSpeed));
        }
    }

    public void jump()
    {
        Vector3 direction = Mouse.transform.position - transform.position;

        _rb.AddForce((new Vector2(direction.x, direction.y)).normalized * jumpForce, ForceMode2D.Impulse);
    }
}
