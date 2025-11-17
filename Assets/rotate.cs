using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{
    //public float moveSpeed = 5f; // 物体移动速度
    //public float jumpForce = 10f; // 物体跳跃力量
    public float speed = 45;
    //private Rigidbody rb;
    //private bool isJumping = false; // 用于判断物体是否正在跳跃

    void Start()
    {
        //rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            transform.Rotate(Vector3.up * speed * Time.deltaTime);

        }
    }



}