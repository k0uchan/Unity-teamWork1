using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameramove : MonoBehaviour
{
    public enum RotationAxes
    {
        MouseXAndY = 0,
        MouseX = 1,
        MouseY = 2
    }
    public RotationAxes axes = RotationAxes.MouseXAndY;
    public float sensitivityHor = 9.0f;
    public float sensitivityVer = 9.0f;
    public float minimumVert = -45.0f;
    public float maximumVert = 45.0f;
    private float verticalRot = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody body = GetComponent<Rigidbody>();
        if (body != null)
        {
            body.freezeRotation = true;
        }

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (axes == RotationAxes.MouseX)
            transform.Rotate(0, -Input.GetAxis("Mouse X") * sensitivityHor, 0);
        else if (axes == RotationAxes.MouseY)
        {
            verticalRot += -Input.GetAxis("Mouse Y") * sensitivityVer;
            verticalRot = Mathf.Clamp(verticalRot, minimumVert, maximumVert);
            float horizontalRot = transform.localEulerAngles.y;
            transform.localEulerAngles = new Vector3(horizontalRot, horizontalRot, 0);
        }
        else
        {
            verticalRot -= -Input.GetAxis("Mouse Y") * sensitivityVer;
            verticalRot = Mathf.Clamp(verticalRot, minimumVert, maximumVert);
            float horizontalRot = transform.localEulerAngles.y;
            float horizontalDelta = -Input.GetAxis("Mouse X") * sensitivityHor;
            horizontalRot += horizontalDelta;
            transform.localEulerAngles = new Vector3(verticalRot, horizontalRot, 0);
            

            Debug.Log("Mouse Y: " + Input.GetAxis("Mouse Y"));
            // 同时控制水平与垂直旋转
    // verticalRot -= Input.GetAxis("Mouse Y") * sensitivityVer;
    // verticalRot = Mathf.Clamp(verticalRot, minimumVert, maximumVert);

    // float horizontalDelta = Input.GetAxis("Mouse X") * sensitivityHor;
    // transform.Rotate(0, horizontalDelta, 0, Space.World);

    // transform.localEulerAngles = new Vector3(verticalRot, transform.localEulerAngles.y, 0);
        }
    }
}
