using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Vehicle : MonoBehaviour
{
    public Bay currentBay {get; set; }
    public Node currentLocation { get; set; }
    public Node destination { get; set; }
    public VehicleBaseState onDestinationReachedState {get; set; }

    private VehicleStateManager stateManager;

    void Awake()
    {
        stateManager = GetComponent<VehicleStateManager>();
    }

    public void Initialise(Node current, Node dest)
    {
        currentLocation = current;
        destination = dest;
        onDestinationReachedState = stateManager.parkState;
        transform.position = current.transform.position;

        stateManager.SwitchState(stateManager.driveToDestinationState);
    }
}
