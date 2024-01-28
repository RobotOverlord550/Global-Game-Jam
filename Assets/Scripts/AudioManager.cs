using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;
    public AudioSource menuMusic;
    public AudioSource battleMusic;
    public Slider musicSlider;
    public Slider SFXSlider;
    public float musicVol = 1;
    public float SFXVol = 1;
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
        menuMusic.volume = musicVol;
        battleMusic.Stop();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangVol()
    {
        musicVol = musicSlider.value;
        SFXVol = SFXSlider.value;
        menuMusic.volume = musicVol;
    }

    public void PlayCollision()
    {

    }
}
