using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTitle()
    {
        SceneManager.LoadScene("Main menu");
        AudioManager.Instance.menuMusic.Play();
    }

    public void OnQuit()
    {
        Application.Quit();
    }
}
