using GONet;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : GONetBehaviour
{
    public GONetParticipant playerPrefab;

    
    //sets which of the spawnPoints to use
    public GameObject[] spawnPoints;


    //
    private int serverPlayerCount = 0;

    private PlayerController clientMyPlayer;

    public override void OnGONetClientVsServerStatusKnown(bool isClient, bool isServer, ushort myAuthorityId)
    {
        base.OnGONetClientVsServerStatusKnown(isClient, isServer, myAuthorityId);
        

        if (isClient)
        {
            if (SelectStage.chaos)
            {
                RandomizeSpawn();
            }
            Instantiate(playerPrefab);
            EventBus.Subscribe<AssignSpawnpointEvent>(ClientProcessAssignment);
        }
    }

    private void ClientProcessAssignment(GONetEventEnvelope<AssignSpawnpointEvent> eventEnvelope)
    {
        clientMyPlayer.transform.position = spawnPoints[eventEnvelope.Event.spawnpointassignment].transform.position;
    }

   private void RandomizeSpawn()
    {
        foreach (GameObject gameObject in spawnPoints)
        {
            Collider2D collider = gameObject.GetComponent<CircleCollider2D>();
            ContactFilter2D filter = new ContactFilter2D().NoFilter();
            List<Collider2D> results = new List<Collider2D>();
            do
            {
                gameObject.transform.position = new Vector2(UnityEngine.Random.Range(-10f, 10f), UnityEngine.Random.Range(-4f, 4f));
            } while (collider.OverlapCollider(filter, results) > 0);
        }
    }
    

    public override void OnGONetParticipantEnabled(GONetParticipant gonetParticipant)
    {
        base.OnGONetParticipantEnabled(gonetParticipant);

        gonetParticipant.gameObject.GetComponent<Stick>().goNetParticipant = gonetParticipant;

        if (IsServer)
        {
            if (gonetParticipant.GetComponent<PlayerController>())
            {

                ServerSendPlayerSpawnPoint(serverPlayerCount, gonetParticipant);
                serverPlayerCount++;
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
                    Rigidbody2D rigidComponent = playerController.GetComponent<Rigidbody2D>();
                    rigidComponent.isKinematic= true;
                }

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
