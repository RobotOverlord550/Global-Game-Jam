
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldBorder : MonoBehaviour
{
    private void OnTriggerExit2D(UnityEngine.Collider2D collision)
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
