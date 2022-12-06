using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;
using Random=UnityEngine.Random;

public class VehicleParkedState : VehicleBaseState 
{
    private Vehicle vehicle;
    private Node goal;
    private NavMeshAgent agent;
    private Queue<Node> pathToDestination;

    private float timeRemaining = 10f;

    private bool isRunning = false;

    public override void EnterState(VehicleStateManager stateManager) 
    {
        vehicle = stateManager.GetComponent<Vehicle>();
        if (vehicle == null)
        {
            throw new Exception("No vehicle component found");
        }

        timeRemaining = Random.Range(20, 40);
    }

    public override void UpdateState(VehicleStateManager stateManager) 
    {

        if (timeRemaining > 0f)
        {
            timeRemaining -= Time.deltaTime;
        }

        if (timeRemaining <= 0f)
        {
            vehicle.destination = ServiceLocator.Instance.SpawnService.exitPoints[Random.Range(0, ServiceLocator.Instance.SpawnService.exitPoints.Length)];

            Debug.Log(stateManager.gameObject.name + " " + vehicle.destination.name);

            vehicle.onDestinationReachedState = stateManager.despawnState;
            stateManager.SwitchState(stateManager.driveToDestinationState);

            vehicle.currentBay.vehicle = null;
            vehicle.currentBay = null;
        }
    }

    public override void OnCollisionEnter(VehicleStateManager stateManager)
    {

    }
}