using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitCamera : MonoBehaviour
{
    [SerializeField] private Transform target;
    public float rotSpeed_ = 1.5f;
    private float rotY_;
    private Vector3 offset_;
    void Start()
    {
        rotY_ = transform.eulerAngles.y;
        offset_ = target.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void LateUpdate()
    {
        float horInput = Input.GetAxis("Horizontal");
        if (horInput != 0)
        {
            rotY_ = horInput * rotSpeed_;
        }
        else
        {
            rotY_ = Input.GetAxis("Mouse X") * rotSpeed_ * 3;
        }
        Quaternion rotation = Quaternion.Euler(0, rotY_, 0);
        transform.position = target.position - (rotation * offset_);
        transform.LookAt(target);
    }
}
