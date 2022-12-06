using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Camera[] cameras;
    public Camera freeCamera;

    public int currentCamera = 0;

    // Start is called before the first frame update
    void Start()
    {

        if (cameras.Length == 0)
        {
            throw new System.Exception("No cameras set ");
        }

        DisableCameras();
        EnableCamera(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            EnableCamera(0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            EnableCamera(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            EnableCamera(2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            EnableCamera(3);
        }
        else if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (freeCamera.gameObject.activeSelf)
            {
                EnableCamera(currentCamera);
            }
            else
            {
                EnableFreeCamera();
            }
        }
    }

    private void EnableFreeCamera()
    {
        freeCamera.gameObject.transform.position = cameras[currentCamera].transform.position;
        freeCamera.gameObject.transform.rotation = cameras[currentCamera].transform.rotation;
        DisableCameras();
        freeCamera.gameObject.SetActive(true);
    }

    private void DisableCameras()
    {
        foreach(Camera camera in cameras)
        {
            camera.gameObject.SetActive(false);
        }
        freeCamera.gameObject.SetActive(false);
    }

    private void EnableCamera(int index)
    {
        DisableCameras();
        currentCamera = index;
        cameras[index].gameObject.SetActive(true);
    }
}
