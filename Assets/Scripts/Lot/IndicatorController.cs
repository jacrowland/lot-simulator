using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicatorController : MonoBehaviour
{
    public Material occupiedMaterial;
    public Material freeMaterial;
    public Material reservedMaterial;
    public bool isReserved = false;
    public bool isOccupied = false;
    private MeshRenderer meshRenderer;

    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }
    // Update is called once per frame
    void Update()
    {
        if (isOccupied) {
            meshRenderer.material = occupiedMaterial;
        }
        else if (isReserved) {
            meshRenderer.material = reservedMaterial;
        }
        else {
            meshRenderer.material = freeMaterial;
        }
    }
}
