using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;
using Random=UnityEngine.Random;

public class VehicleParkState : VehicleBaseState 
{
    private Vehicle vehicle;
    private Node goal;
    private NavMeshAgent agent;
    private Queue<Node> pathToDestination;

    private bool isRunning = false;

    public override void EnterState(VehicleStateManager stateManager) 
    {
        vehicle = stateManager.GetComponent<Vehicle>();
        if (vehicle == null)
        {
            throw new Exception("No vehicle component found");
        }

        Bay bay = ManagerLocator.Instance.LotManager.GetUnoccupiedBay();

        if (bay == null)
        {
            vehicle.currentLocation = ManagerLocator.Instance.LotManager.entrance;
            vehicle.destination = ServiceLocator.Instance.SpawnService.exitPoints[Random.Range(0, ServiceLocator.Instance.SpawnService.exitPoints.Length)];   
            vehicle.onDestinationReachedState = stateManager.despawnState;
        }
        else {
            vehicle.destination = bay.GetComponent<Node>();
            vehicle.currentLocation = ManagerLocator.Instance.LotManager.entrance;

            vehicle.destination = bay.GetComponent<Node>();
            if (vehicle.destination == null)
            {
                throw new Exception("No Node found on Bay");
            }
            if (vehicle.currentLocation == null)
            {
                throw new Exception("No currentLocation Node found on Vehicle");
            }
             // reserve the bay so another vehicle does not attempt to park there
             bay.vehicle = vehicle;
             vehicle.currentBay = bay;

            // Go idle once you have parked
            vehicle.onDestinationReachedState = stateManager.parkedState;
        }

        stateManager.SwitchState(stateManager.driveToDestinationState);
    }

    public override void UpdateState(VehicleStateManager stateManager) 
    {

    }

    public override void OnCollisionEnter(VehicleStateManager stateManager)
    {

    }
    
}