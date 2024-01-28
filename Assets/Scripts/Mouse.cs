using GONet;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    public GameObject player;

    [SerializeField] GONetParticipant _goNetParticipant;
    [SerializeField] GameObject _playerPrefab;

    PInput _pInput;

    private void Awake()
    {
        _pInput = new PInput();
    }

    private void OnEnable()
    {
        _pInput.Enable();
        _pInput.Player.Jump.performed += Jump_performed;
    }

    private void OnDisable()
    {
        _pInput.Disable();
        _pInput.Player.Jump.performed -= Jump_performed;
    }

    void Update()
    {
        if (_goNetParticipant.IsMine)
        {
            Vector3 newPos = Camera.main.ScreenToWorldPoint(_pInput.Player.Mouse.ReadValue<Vector2>());
            transform.position = new Vector3(newPos.x, newPos.y, transform.position.z);
        }
    }
    private void Jump_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        player.GetComponent<Player>().jump();
    }
}
