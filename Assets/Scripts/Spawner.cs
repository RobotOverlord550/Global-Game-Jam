using GONet;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : GONetBehaviour
{
    public GONetParticipant _mousePrefab;
    public GONetParticipant _playerPrefab;

    public Transform[] spawnPoints;
    public Transform[] playerIcons;

    private int serverPlayerCount = 0;

    private PlayerController clientMyPlayer;

    public override void OnGONetClientVsServerStatusKnown(bool isClient, bool isServer, ushort myAuthorityId)
    {
        base.OnGONetClientVsServerStatusKnown(isClient, isServer, myAuthorityId);
        

        if (isClient)
        {
            Instantiate(_mousePrefab);
            EventBus.Subscribe<AssignSpawnpointEvent>(ClientProcessAssignment);
        }
    }

    private void ClientProcessAssignment(GONetEventEnvelope<AssignSpawnpointEvent> eventEnvelope)
    {
        clientMyPlayer.transform.position = spawnPoints[eventEnvelope.Event.spawnpointassignment].position; 
    }

   
    

    public override void OnGONetParticipantEnabled(GONetParticipant gonetParticipant)
    {
        base.OnGONetParticipantEnabled(gonetParticipant);

        if (IsServer)
        {
            if (gonetParticipant.GetComponent<PlayerController>())
            {
                ServerSendPlayerSpawnPoint(serverPlayerCount, gonetParticipant);
                serverPlayerCount++;
            }
            if (gonetParticipant.GetComponent<Mouse>())
            {
                GONetParticipant player = Instantiate(_playerPrefab);
                player.GetComponent<Player>().Mouse = gonetParticipant.gameObject;
                gonetParticipant.gameObject.GetComponent<Mouse>().player = player.gameObject;
            }
        }else if (IsClient)
        {
            if (gonetParticipant.GetComponent<PlayerController>())
            {
                PlayerController playerController = gonetParticipant.GetComponent<PlayerController>();

                if (gonetParticipant.IsMine)
                {
                    clientMyPlayer = playerController;

                }
                else
                {
                    //Rigidbody2D rigidComponent = playerController.GetComponent<Rigidbody2D>();
                    //rigidComponent.isKinematic= true;
                }

            }
            if (gonetParticipant.GetComponent<Player>())
            {
                gonetParticipant.GetComponent<Rigidbody2D>().isKinematic = true;
            }

        }
    }

    private void ServerSendPlayerSpawnPoint(int serverPlayerCount, GONetParticipant gonetParticipant)
    {
        AssignSpawnpointEvent spawningEvent = new AssignSpawnpointEvent();

        spawningEvent.spawnpointassignment = serverPlayerCount;

        EventBus.Publish(spawningEvent,targetClientAuthorityId:gonetParticipant.OwnerAuthorityId);
    }

   

}

[MemoryPack.MemoryPackable]
public partial class AssignSpawnpointEvent : ITransientEvent
{
    public long OccurredAtElapsedTicks => 0;

    public int spawnpointassignment;




}
