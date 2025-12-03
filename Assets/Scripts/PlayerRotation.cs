using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    public float sensitivityHor = 9.0f;

    void Update()
    {
         if (Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt) || Input.GetKey(KeyCode.Tab))
        {
            return;
        }
        float rotY = Input.GetAxis("Mouse X") * sensitivityHor;
        transform.Rotate(0, rotY, 0); // 只绕Y轴水平旋转
    }
}
