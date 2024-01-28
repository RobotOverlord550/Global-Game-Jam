using GONet;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : GONetBehaviour
{
    public GONetParticipant PlayerPrefab;


    //sets which of the spawnPoints to use
    public Transform[] spawnPoints;


    //
    private int serverPlayerCount = 0;

    private Stick clientMyPlayer;

    public override void OnGONetClientVsServerStatusKnown(bool isClient, bool isServer, ushort myAuthorityId)
    {
        base.OnGONetClientVsServerStatusKnown(isClient, isServer, myAuthorityId);


        if (isClient)
        {
            Instantiate(PlayerPrefab);
            Debug.Log("Person Created");
            EventBus.Subscribe<AssignSpawnpointEvent>(ClientProcessAssignment);
            Debug.Log("Person Placed on spawnpoint");
        }
    }

    private void ClientProcessAssignment(GONetEventEnvelope<AssignSpawnpointEvent> eventEnvelope)
    {
        clientMyPlayer.transform.position = spawnPoints[eventEnvelope.Event.spawnpointassignment].position;
        Debug.Log("Spawning stuff");
    }




    public override void OnGONetParticipantEnabled(GONetParticipant gonetParticipant)
    {
        base.OnGONetParticipantEnabled(gonetParticipant);

        if (IsServer)
        {
            if (gonetParticipant.GetComponent<Stick>())
            {

                ServerSendPlayerSpawnPoint(serverPlayerCount, gonetParticipant);
                serverPlayerCount++;
                Debug.Log("Server Player Count Updated");
                // when spawning more than two players, reset back to first spot
                //if (serverPlayerCount >= 2)
                //{
                  //  serverPlayerCount = 0;
                //}
            }
        }
        else if (IsClient)
        {
            if (gonetParticipant.GetComponent<Stick>())
            {
                Stick playerController = gonetParticipant.GetComponent<Stick>();

                if (gonetParticipant.IsMine)
                {
                    clientMyPlayer = playerController;

                }
                else
                {
                    Rigidbody2D rigidComponent = playerController.GetComponent<Rigidbody2D>();
                    rigidComponent.isKinematic = true;
                }

            }

        }
    }

    private void ServerSendPlayerSpawnPoint(int serverPlayerCount, GONetParticipant gonetParticipant)
    {
        AssignSpawnpointEvent spawningEvent = new AssignSpawnpointEvent();

        spawningEvent.spawnpointassignment = serverPlayerCount;

        EventBus.Publish(spawningEvent, targetClientAuthorityId: gonetParticipant.OwnerAuthorityId);

        Debug.Log("Just published");
    }



}

[MemoryPack.MemoryPackable]
public partial class AssignSpawnpointEvent : ITransientEvent
{
    public long OccurredAtElapsedTicks => 0;

    public int spawnpointassignment;




}