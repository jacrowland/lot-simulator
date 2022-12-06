using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;

public class VehicleDespawnState : VehicleBaseState 
{
    private Vehicle vehicle;
    private Node goal;
    private NavMeshAgent agent;
    private Queue<Node> pathToDestination;

    private bool isRunning = false;

    public override void EnterState(VehicleStateManager stateManager) 
    {
        Debug.Log("Destroying " + stateManager.gameObject.name + "...");
        GameObject.Destroy(stateManager.gameObject);
    }

    public override void UpdateState(VehicleStateManager stateManager) 
    {

    }

    public override void OnCollisionEnter(VehicleStateManager stateManager)
    {

    }
    
}