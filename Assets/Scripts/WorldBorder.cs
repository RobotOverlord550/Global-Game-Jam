using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

public class WorldBorder : MonoBehaviour
{
    private void OnTriggerEnter2D(UnityEngine.Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            handldeDeath();
        }
    }

    private void handldeDeath()
    {
        SceneManager.LoadScene("Death");
        AudioManager.Instance.battleMusic.Stop();
    }
}
