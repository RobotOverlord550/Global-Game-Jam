using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectStage : MonoBehaviour
{
    public static bool chaos = false;
    // Start is called before the first frame update
    void Start()
    {
        chaos = false; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnChaos()
    {
        chaos = true;
        SceneManager.LoadScene("Chaos");
        AudioManager.Instance.menuMusic.Stop();
        AudioManager.Instance.battleMusic.Play();
        AudioManager.Instance.battleMusic.loop = true;
        AudioManager.Instance.battleMusic.volume = AudioManager.Instance.musicVol;
    }

    public void OnBasic()
    {
        SceneManager.LoadScene("Chaos");
        AudioManager.Instance.menuMusic.Stop();
        AudioManager.Instance.battleMusic.Play();
        AudioManager.Instance.battleMusic.loop = true;
        AudioManager.Instance.battleMusic.volume = AudioManager.Instance.musicVol;
    }

    public void OnPirate()
    {
        SceneManager.LoadScene("Chaos");
        AudioManager.Instance.menuMusic.Stop();
        AudioManager.Instance.battleMusic.Play();
        AudioManager.Instance.battleMusic.loop = true;
        AudioManager.Instance.battleMusic.volume = AudioManager.Instance.musicVol;
    }

    public void OnBBBB()
    {
        SceneManager.LoadScene("Chaos");
        AudioManager.Instance.menuMusic.Stop();
        AudioManager.Instance.battleMusic.Play();
        AudioManager.Instance.battleMusic.loop = true;
        AudioManager.Instance.battleMusic.volume = AudioManager.Instance.musicVol;
    }

    public void OnStar()
    {
        SceneManager.LoadScene("Chaos");
        AudioManager.Instance.menuMusic.Stop();
        AudioManager.Instance.battleMusic.Play();
        AudioManager.Instance.battleMusic.loop = true;
        AudioManager.Instance.battleMusic.volume = AudioManager.Instance.musicVol;
    }

    public void On911()
    {
        SceneManager.LoadScene("Chaos");
        AudioManager.Instance.menuMusic.Stop();
        AudioManager.Instance.battleMusic.Play();
        AudioManager.Instance.battleMusic.loop = true;
        AudioManager.Instance.battleMusic.volume = AudioManager.Instance.musicVol;
    }
}
