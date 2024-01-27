using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        //death menu code
    }
}
