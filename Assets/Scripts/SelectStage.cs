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
    }

    public void OnBasic()
    {
        SceneManager.LoadScene("Chaos");
    }

    public void OnPirate()
    {
        SceneManager.LoadScene("Chaos");
    }

    public void OnBBBB()
    {
        SceneManager.LoadScene("Chaos");
    }

    public void OnStar()
    {
        SceneManager.LoadScene("Chaos");
    }

    public void On911()
    {
        SceneManager.LoadScene("Chaos");
    }
}
