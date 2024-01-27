using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionAudio : MonoBehaviour
{
    [SerializeField] AudioManager _audioManager;
    [SerializeField] float minSpaceBetweenClips;

    float clipTimer = 0;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(clipTimer <= 0)
        {
            _audioManager.playCollison();
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
