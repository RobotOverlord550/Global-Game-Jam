using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Play : MonoBehaviour
{
    [SerializeField] private Slider music;
    [SerializeField] private Slider sfx;
    [SerializeField] private Button play;
    [SerializeField] private Button settings;
    [SerializeField] private Button quit;
    [SerializeField] private Button back;
    [SerializeField] private TextMeshProUGUI title;
    // Start is called before the first frame update
    void Start()
    {
        music.gameObject.SetActive(false);
        sfx.gameObject.SetActive(false);
        back.gameObject.SetActive(false);
        play.gameObject.SetActive(true);
        settings.gameObject.SetActive(true);
        quit.gameObject.SetActive(true);
        title.gameObject.SetActive(true);
        music.value = 1;
        sfx.value = 1;
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
        music.gameObject.SetActive(true);
        sfx.gameObject.SetActive(true);
        back.gameObject.SetActive(true);
        play.gameObject.SetActive(false);
        settings.gameObject.SetActive(false);
        quit.gameObject.SetActive(false);
        title.gameObject.SetActive(false);
    }

    public void OnBack()
    {
        music.gameObject.SetActive(false);
        sfx.gameObject.SetActive(false);
        back.gameObject.SetActive(false);
        play.gameObject.SetActive(true);
        settings.gameObject.SetActive(true);
        quit.gameObject.SetActive(true);
        title.gameObject.SetActive(true);
    }

    public void OnQuit()
    {
        Application.Quit();
    }
}
