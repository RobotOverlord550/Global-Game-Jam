using GONet;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : GONetBehaviour
{
    public GONetParticipant playerPrefab;

    public override void OnGONetClientVsServerStatusKnown(bool isClient, bool isServer, ushort myAuthorityId)
    {
        base.OnGONetClientVsServerStatusKnown(isClient, isServer, myAuthorityId);

        if (isClient)
        {
            Instantiate(playerPrefab);
        }
    }
}
