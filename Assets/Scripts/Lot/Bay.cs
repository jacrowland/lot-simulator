using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Bay : MonoBehaviour
{
    public bool isOccupied { get; private set; } = false;
    public Vehicle vehicle;
    public IndicatorController overheadIndicator;
    public Node node {get; private set; }

    void OnEnable()
    {
        overheadIndicator = GetComponentInChildren<IndicatorController>();

        if (overheadIndicator == null)
        {
            throw new Exception("Cannot find the overhead indicator controller");
        }

        node = GetComponent<Node>();
        if (node == null)
        {
            throw new Exception("Cannot find the Bay node");
        }
    }

    void Update()
    {
        if (overheadIndicator != null)
        {
            if (vehicle != null && !isOccupied)
            {
                overheadIndicator.isReserved = true;
            }
            else if (isOccupied)
            {
                overheadIndicator.isOccupied = isOccupied;
            }
            else {
                overheadIndicator.isOccupied = false;
                overheadIndicator.isReserved = false;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        other.transform.rotation = node.transform.rotation;
        other.transform.position = node.transform.position;
        vehicle = other.gameObject.GetComponent<Vehicle>();
        isOccupied = true;
    }

    void OnTriggerExit(Collider other)
    {
        isOccupied = false;
        vehicle = null;
    }
}
