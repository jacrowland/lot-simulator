using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;
using Random=UnityEngine.Random;

public class VehicleDriveToDestinationState : VehicleBaseState 
{
    private Vehicle vehicle;
    private Node goal;
    private NavMeshAgent agent;
    private Queue<Node> pathToDestination;

    private bool isRunning = false;

    public override void EnterState(VehicleStateManager stateManager) 
    {
        agent = stateManager.GetComponent<NavMeshAgent>();
        
        if (agent == null)
        {
            throw new Exception("No NavMeshAgent component found");
        }

        vehicle = stateManager.GetComponent<Vehicle>();
        if (vehicle == null)
        {
            throw new Exception("No vehicle component found");
        }

        goal = vehicle.destination;
        if (goal == null)
        {
            throw new Exception("No destination Node found on Vehicle");
        }

        if (vehicle.currentLocation == null)
        {
            throw new Exception("No currentLocation Node found on Vehicle");
        }

        List<Node> path = ServiceLocator.Instance.PathFinderService.GetPath(vehicle.currentLocation, goal);
        if (path == null)
        {
            Debug.Log(stateManager.gameObject.name + " cannot find path...");
            stateManager.SwitchState(stateManager.despawnState);
            //throw new Exception("No path found between currentLocation and Destination");
        }
        else if (path.Count == 0) {
            throw new Exception("Path of length 0 found");
        }

        pathToDestination = new Queue<Node>(path);

        Node start = pathToDestination.Dequeue();

        agent.isStopped = false;
    }

    private float GetDistanceToCurrentDestination()
    {
        return Vector3.Distance(vehicle.transform.position, agent.destination);
    }

    private bool HasReachedGoal()
    {
        return Vector3.Distance(vehicle.transform.position, goal.transform.position) < 1f;
    }

    public override void UpdateState(VehicleStateManager stateManager) 
    {
        if (!agent.isStopped)
        {
            if (HasReachedGoal())
            {
                agent.isStopped = true;
                vehicle.currentLocation = vehicle.destination;
                vehicle.destination = null;

                VehicleBaseState state = vehicle.onDestinationReachedState;
                vehicle.onDestinationReachedState = null;
                stateManager.SwitchState(state);
            }
            else if (GetDistanceToCurrentDestination() < 2f && pathToDestination.Count > 0)
            {
                UpdateWaypoint();
            }
        }
    }

    private void UpdateWaypoint()
    {
        Node node;
        pathToDestination.TryDequeue(out node);
        agent.SetDestination(node.transform.position);
    }

    public override void OnCollisionEnter(VehicleStateManager stateManager)
    {

    }
    
}