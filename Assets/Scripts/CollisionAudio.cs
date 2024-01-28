using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionAudio : MonoBehaviour
{
    [SerializeField] float minSpaceBetweenClips;

    AudioManager _audioManager;
    float clipTimer = 0;

    private void Awake()
    {
        _audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(clipTimer <= 0)
        {
            _audioManager.PlayCollision();
            clipTimer = minSpaceBetweenClips;
        }
    }

    private void Update()
    {
        if(clipTimer > 0)
        {
            clipTimer -= Time.deltaTime;
        }
    }
}
