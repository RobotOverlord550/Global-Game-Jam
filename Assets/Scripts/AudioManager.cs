using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;
    public AudioSource menuMusic;
    public AudioSource battleMusic;
    public static AudioManager Instance
    {
        get
        {
            if (instance == null)
            {
                Debug.Log("No sound");
            }
            return instance;
        }
    }

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this);
    }
    // Start is called before the first frame update
    void Start()
    {
        menuMusic.Play();
        menuMusic.loop = true;
        battleMusic.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayCollision()
    {

    }
}
