using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPlay()
    {
        SceneManager.LoadScene("Stage Select");
    }

    public void OnSettings()
    {

    }

    public void OnQuit()
    {
        Application.Quit();
    }
}
