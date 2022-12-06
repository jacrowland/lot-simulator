using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinderService : MonoBehaviour
{

    public List<Node> GetPath(Node start, Node goal)
    {
        List<Node> path = AStar(start, goal);
        if (path != null) {
            return path;
        }
        return null;
    }

    private List<Node> AStar(Node start, Node goal)
    {

        Dictionary<string, Node> openSet = new Dictionary<string, Node>();
        Dictionary<string, Node> cameFrom = new Dictionary<string, Node>();
        Dictionary<string, float> gScore = new Dictionary<string, float>();
        Dictionary<string, float> fScore = new Dictionary<string, float>();

        openSet.Add(start.name, start);
        gScore.Add(start.name, 0);
        fScore.Add(start.name, h(start, goal));

        while (openSet.Count > 0)
        {
            Node current = lowestFScore(openSet, fScore);

            if (current == goal)
            {

                return reconstructPath(cameFrom, current);
            }

            openSet.Remove(current.name);

            for (int i = 0; i < current.neighbors.Count; i++)
            {
                GameObject neighbour = current.neighbors[i];
                if (neighbour != null)
                {
                    float currentGScore;
                    float neighbourGScore;

                    if (!gScore.TryGetValue(neighbour.name, out neighbourGScore))
                    {
                        neighbourGScore = float.PositiveInfinity;
                    };

                    if (gScore.TryGetValue(current.name, out currentGScore))
                    {
                        float tentativeGScore = currentGScore + Vector3.Distance(current.transform.position, neighbour.transform.position);

                        if (tentativeGScore < neighbourGScore)
                        {
                            cameFrom[neighbour.name] = current;
                            gScore[neighbour.name] = tentativeGScore;
                            fScore[neighbour.name] = tentativeGScore + h(neighbour.GetComponent<Node>(), goal);
                            if (!openSet.ContainsKey(neighbour.name))
                            {
                                openSet[neighbour.name] = neighbour.GetComponent<Node>();
                            }
                        }
                    }

                }


            }
        }
        return null; // failure
    }

    private List<Node> reconstructPath(Dictionary<string, Node> cameFrom, Node current)
    {
        List<Node> path = new List<Node>();
        path.Add(current);
        while (cameFrom.ContainsKey(current.name))
        {
            current = cameFrom[current.name];
            path.Add(current);
        }
        path.Reverse();
        return path;
    }

    private Node lowestFScore(Dictionary<string, Node> openSet, Dictionary<string, float> fScore)
    {
        float lowestFScore = float.PositiveInfinity;
        Node node = null;

        foreach (string key in openSet.Keys)
        {
            float value;
            if (fScore.TryGetValue(key, out value))
            {
                if (value < lowestFScore)
                {
                    lowestFScore = value;
                    openSet.TryGetValue(key, out node);
                }
            }
        }

        return node;
    }
    private float h(Node current, Node goal)
    {
        /*
        *    Euclidean distance hueristic
        */
        return Vector3.Distance(current.transform.position, goal.transform.position);
    }

    

}

