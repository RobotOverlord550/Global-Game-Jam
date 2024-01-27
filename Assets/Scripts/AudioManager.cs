using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource _audioSource;
    [SerializeField] List<AudioClip> _collisionClips = new List<AudioClip>();

    public void playCollison()
    {
        _audioSource.PlayOneShot(_collisionClips[Random.Range(0, _collisionClips.Count - 1)]);
    }
}
