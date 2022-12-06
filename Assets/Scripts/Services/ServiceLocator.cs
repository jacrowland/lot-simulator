using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServiceLocator : MonoBehaviour
{

    public static ServiceLocator Instance { get; private set; }
    public SpawnService SpawnService {get; private set; }
    public PathFinderService PathFinderService {get; private set; }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;
        SpawnService = GetComponentInChildren<SpawnService>();
        PathFinderService = GetComponentInChildren<PathFinderService>();
    }

}
