using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lockRotation : MonoBehaviour
{
    private void Update()
    {
        handleFollowPlayer();
    }
    void handleFollowPlayer()
    {
        transform.eulerAngles = Vector3.zero;
    }
}
