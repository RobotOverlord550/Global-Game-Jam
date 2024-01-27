using GONet;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : GONetParticipantCompanionBehaviour
{
    void Update()
    {
        if (IsMine)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                transform.position += new Vector3(0, 10 * Time.deltaTime, 0);
            }
        }
    }
}
