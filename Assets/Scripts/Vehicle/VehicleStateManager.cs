using UnityEngine;

public class VehicleStateManager : MonoBehaviour {

    public VehicleBaseState currentState;
    public VehicleDriveToDestinationState driveToDestinationState = new VehicleDriveToDestinationState();
    public VehicleIdleState idleState = new VehicleIdleState();
    public VehicleParkState parkState = new VehicleParkState();
    public VehicleDespawnState despawnState = new VehicleDespawnState();
    public VehicleParkedState parkedState = new VehicleParkedState();
    public VehicleBaseState defaultState;

    public void OnEnable() 
    {
        currentState = idleState;
        currentState.EnterState(this);
    }

    public void Update() 
    {
        currentState.UpdateState(this);
    }

    public void SwitchState(VehicleBaseState state) 
    {
        currentState = state;
        currentState.EnterState(this);
    }
}