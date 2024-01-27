using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] GameObject _player;

    private void Update()
    {
        transform.position = _player.transform.position;
    }
}
