using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeCameraController : MonoBehaviour
{
    public float Sensitivity {
		get { return sensitivity; }
		set { sensitivity = value; }
	}

	[Range(0.1f, 9f)][SerializeField] float sensitivity = 2f;
	[Tooltip("Limits vertical camera rotation. Prevents the flipping that happens when rotation goes above 90.")]
	[Range(0f, 90f)][SerializeField] float yRotationLimit = 88f;

	Vector2 rotation = Vector2.zero;
	const string xAxis = "Mouse X";
	const string yAxis = "Mouse Y";

    private Vector3 movement = new Vector3(0, 0, 0);

    GameObject camera;

    public float moveSpeed = 5f;

    // Start is called before the first frame update
    void OnEnable()
    {
        camera = GetComponent<Camera>().gameObject;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void OnDisable()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    // Update is called once per frame
    void Update()
    {
		rotation.x += Input.GetAxis(xAxis) * sensitivity;
		rotation.y += Input.GetAxis(yAxis) * sensitivity;
		rotation.y = Mathf.Clamp(rotation.y, -yRotationLimit, yRotationLimit);
		var xQuat = Quaternion.AngleAxis(rotation.x, Vector3.up);
		var yQuat = Quaternion.AngleAxis(rotation.y, Vector3.left);
		camera.transform.localRotation = xQuat * yQuat;

        movement = Vector3.zero;
        if (Input.GetKey(KeyCode.A))
        {
            movement += transform.right * -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            movement += transform.right * 1;
        }
        if (Input.GetKey(KeyCode.W))
        {
            movement += transform.forward * 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            movement += transform.forward * -1;
        }
        if (Input.GetKey(KeyCode.Q))
        {
            movement += transform.up * 1;
        }
        if (Input.GetKey(KeyCode.E))
        {
            movement += transform.up * -1;
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            movement = movement * 2 * moveSpeed;
        }
        else
        {
            movement = movement * moveSpeed;
        }

        movement = movement * Time.unscaledDeltaTime;
        transform.position = transform.position + movement;
    }
}
