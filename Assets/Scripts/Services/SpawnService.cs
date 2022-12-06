using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class SpawnService : MonoBehaviour
{
    public Node[] spawnPoints;
    public Node[] exitPoints;
    public GameObject[] prefabs;
    
    public void SpawnVehicle()
    {
        Debug.Log("Spawning vehicle...");
        GameObject prefab = GetRandomVehicle();
        Node spawn = GetRandomSpawnPoint();
        GameObject spawnedVehicle = GameObject.Instantiate(prefab, spawn.transform.position, spawn.transform.rotation);
        Vehicle vehicle = spawnedVehicle.GetComponent<Vehicle>();
        vehicle.Initialise(spawn, ManagerLocator.Instance.LotManager.entrance);
    }

    public void SpawnVehicle(int i)
    {
        Debug.Log("Spawning vehicle..." + i.ToString());
        Node spawn = GetRandomSpawnPoint();
        GameObject spawnedVehicle = GameObject.Instantiate(prefabs[i], spawn.transform.position, spawn.transform.rotation);
        Vehicle vehicle = spawnedVehicle.GetComponent<Vehicle>();
        vehicle.Initialise(spawn, ManagerLocator.Instance.LotManager.entrance);
    }

    private GameObject GetRandomVehicle()
    {
        return prefabs[Random.Range(0, prefabs.Length - 1)];
    }

    public Node GetRandomSpawnPoint()
    {
       return spawnPoints[Random.Range(0, spawnPoints.Length)];
    }

    public Node GetRandomExitPoint()
    {
        return exitPoints[Random.Range(0, exitPoints.Length)];
    }

    void OnAwake()
    {
        if (prefabs.Length == 0)
        {
             throw new Exception("No prefabs defined");
        }

        if (spawnPoints.Length == 0)
        {
            throw new Exception("Please define at least one spawn point");
        }

        if (exitPoints.Length == 0)
        {
            throw new Exception("Please define at least one exit point");
        }
    }
}
