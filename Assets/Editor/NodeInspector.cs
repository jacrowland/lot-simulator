using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

[CustomEditor(typeof(Node))]
public class NodeInspector : Editor
{

    Node node;

    void OnEnable() {
        node = target as Node;
    }

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
    }

    void OnSceneGUI() {
        Handles.Label(node.transform.position - Vector3.down, node.name);

        GameObject[] neighbours = node.neighbors.ToArray();
        if (neighbours == null) {
            return;
        }

        Vector3 center = node.transform.position;
        for (int i = 0; i < neighbours.Length; i++) {
            
            GameObject neighbour = neighbours[i];

            if (neighbour) {
                Handles.DrawLine(center, neighbour.transform.position);
            }
            else {
                return;
            }
        }
    }
}
