using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LotManager : MonoBehaviour
{
    public Node entrance;
    public Node exit;
    public Bay[] bays;

    public Bay GetUnoccupiedBay()
    {
        List<Bay> unoccupied = new List<Bay>();

        foreach (Bay bay in bays)
        {
            if (!bay.isOccupied && bay.vehicle == null)
            {
                unoccupied.Add(bay);
            }
        }

        if (unoccupied.Count > 0)
        {
            return unoccupied[Random.Range(0, unoccupied.Count - 1)];
        }
        return null;
    }

    public int GetOccupiedBayCount()
    {
        int count = 0;
        foreach (Bay bay in bays)
        {
            if (bay.isOccupied)
            {
                count += 1;
            }
        }
        return count;
    }
}
