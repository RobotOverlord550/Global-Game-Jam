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
    }

    public void OnBasic()
    {
        SceneManager.LoadScene("Chaos");
        AudioManager.Instance.menuMusic.Stop();
        AudioManager.Instance.battleMusic.Play();
    }

    public void OnPirate()
    {
        SceneManager.LoadScene("Chaos");
        AudioManager.Instance.menuMusic.Stop();
        AudioManager.Instance.battleMusic.Play();
    }

    public void OnBBBB()
    {
        SceneManager.LoadScene("Chaos");
        AudioManager.Instance.menuMusic.Stop();
        AudioManager.Instance.battleMusic.Play();
    }

    public void OnStar()
    {
        SceneManager.LoadScene("Chaos");
        AudioManager.Instance.menuMusic.Stop();
        AudioManager.Instance.battleMusic.Play();
    }

    public void On911()
    {
        SceneManager.LoadScene("Chaos");
        AudioManager.Instance.menuMusic.Stop();
        AudioManager.Instance.battleMusic.Play();
    }
}
