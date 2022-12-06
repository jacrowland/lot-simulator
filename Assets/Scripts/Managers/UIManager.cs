using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject timeText;
    private TextMeshProUGUI timeTMP;
    public Image timeImage;
    public TextMeshProUGUI activeCameraTMP;

    public GameObject pauseUI;

    private SimulationController simulation;

    void Start() {
        if (!timeText) 
        {
            throw new Exception("No timeText object set.");
        }

        timeTMP = timeText.GetComponent<TextMeshProUGUI>();
        simulation = GameObject.FindObjectOfType<SimulationController>();


        if (!timeTMP)
        {
            throw new Exception("No timeTMP component found on timeText");
        }
    }

    void Update()
    {
        
        timeTMP.text = Math.Round(simulation.timeRemaining, 0).ToString();
        timeImage.fillAmount = simulation.timeRemaining / simulation.currentSpawnTime;

        activeCameraTMP.text = Camera.current.name;


        if (Time.timeScale == 0)
        {
            pauseUI.SetActive(true);
        }
        else 
        {
            pauseUI.SetActive(false);
        }
    }

}
