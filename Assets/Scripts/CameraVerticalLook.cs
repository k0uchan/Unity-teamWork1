using UnityEngine;

public class CameraVerticalLook : MonoBehaviour
{
    public float sensitivityVer = 9.0f;
    public float minVert = -45.0f;
    public float maxVert = 45.0f;

    private float verticalRot = 0.0f;

    public GameObject illustrateAct;
    public GameObject setActive;

    void Update()
    {
         if (Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt) || illustrateAct.activeSelf||setActive.activeSelf)
        {
            return;
        }
        verticalRot -= Input.GetAxis("Mouse Y") * sensitivityVer;
        verticalRot = Mathf.Clamp(verticalRot, minVert, maxVert);

        
        transform.localEulerAngles = new Vector3(verticalRot, 0, 0);
    }
}
