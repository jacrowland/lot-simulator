using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimulationController : MonoBehaviour
{

    public bool isRunning = true;

    public float currentSpawnTime = 60 / 10;
    public float timeRemaining = 60 / 10;
    public float minSpawnTime = 5f;
    public float maxSpawnTime = 15f;

    public void Pause()
    {
        Time.timeScale = 0;
        isRunning = false;
    }

    public void Resume()
    {
        Time.timeScale = 1;
        isRunning = true;
    }

    void Update()
    {
        if (isRunning)
        {
            timeRemaining -= Time.deltaTime;

            if (timeRemaining < 0)
            {
                Debug.Log("Spawning vehicle...");
                currentSpawnTime = Random.Range(minSpawnTime, maxSpawnTime);
                timeRemaining = currentSpawnTime;
                ServiceLocator.Instance.SpawnService.SpawnVehicle();
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isRunning)
            {
                Pause();
            }
            else
            {
                Resume();
            }
        }

        if (Input.GetKeyDown(KeyCode.Tilde))
        {
            Debug.Log("Spawning vehicle...");
            ServiceLocator.Instance.SpawnService.SpawnVehicle();
        }
    }
}
