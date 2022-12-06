using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class VehicleBaseState { 

    public abstract void EnterState(VehicleStateManager stateManager);

    public abstract void UpdateState(VehicleStateManager stateManager);

    public abstract void OnCollisionEnter(VehicleStateManager stateManager);

}